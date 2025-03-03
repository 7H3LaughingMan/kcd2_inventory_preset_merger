using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

class Program
{
    static Dictionary<ZipPath, DatabaseType> originalItemPresets;
    static Dictionary<ZipPath, DatabaseType> workingItemPresets;
    static ZipPath itemFolder = new ZipPath("Libs/Tables/item/");
    static string workingDirectory = Directory.GetParent(Environment.ProcessPath).FullName;
    static string gameDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

    static void Main()
    {
        LoadGameFiles(gameDirectory);

        var mods = LoadMods(gameDirectory);

        var ignoredMods = File.Exists(Path.Combine(workingDirectory, "mod_ignore.txt"))
            ? File.ReadAllLines(Path.Combine(workingDirectory, "mod_ignore.txt"))
            : [];

        foreach (var mod in mods)
        {
            if (!ignoredMods.Contains(mod.ModId))
                ProcessMod(mod);
        }

        OutputMerge();

        File.WriteAllLines(Path.Combine(gameDirectory, "Mods", "mod_order.txt"), [.. mods.Select(x => x.ModId), "kcd_two_inventory_preset_merger"]);
        Console.WriteLine("Updated mod_order.txt");
        Console.Write("Press any key to continue . . . ");
        Console.ReadKey();
    }

    static void LoadGameFiles(string gamePath)
    {
        originalItemPresets = new Dictionary<ZipPath, DatabaseType>();

        using (var tables = ZipFile.OpenRead(Path.Combine(gamePath, "Data", "Tables.pak")))
        {
            foreach (var entry in tables.Entries)
            {
                var entryPath = new ZipPath(entry.FullName);
                if (entryPath.IsFile &&
                    entryPath.IsWithinFolder(itemFolder) &&
                    entryPath.FileName.StartsWith("InventoryPreset", StringComparison.OrdinalIgnoreCase) &&
                    entryPath.Extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    var gameFile = DatabaseType.Parse(entry.Open());
                    originalItemPresets.Add(entryPath, gameFile);
                }
            }
        }

        workingItemPresets = originalItemPresets.ToDictionary(k => k.Key.Clone() as ZipPath, k => k.Value.Clone() as DatabaseType);
        Console.WriteLine($"Loaded {workingItemPresets.Sum(kvp => kvp.Value.InventoryPresets.InventoryPreset.Count)} Inventory Presets");
    }

    static List<KCD_Mod> LoadMods(string gamePath)
    {
        var mods = new List<KCD_Mod>();

        foreach (var modFolder in Directory.GetDirectories(Path.Combine(gamePath, "Mods")))
        {
            var mod = KCD_Mod.Parse(Path.Combine(modFolder, "mod.manifest"));
            if (!mod.ModId.Equals("kcd_two_inventory_preset_merger"))
                mods.Add(mod);
        }

        mods.Sort((a, b) => a.ModId.CompareTo(b.ModId));

        if (File.Exists(Path.Combine(gamePath, "Mods", "mod_order.txt")))
        {
            var modOrder = File.ReadAllLines(Path.Combine(gamePath, "Mods", "mod_order.txt"));
            var sortedMods = new List<KCD_Mod>();

            foreach (var modId in modOrder)
            {
                var mod = mods.FirstOrDefault(x => string.Equals(x.ModId, modId), null);
                if (mod is not null)
                    sortedMods.Add(mod);
            }

            mods = sortedMods;
        }

        Console.WriteLine($"Loaded {mods.Count} Mods");
        return mods;
    }

    static void ProcessMod(KCD_Mod mod)
    {
        if (Directory.Exists(Path.Combine(mod.Path, "Data")))
        {
            foreach (var pak in Directory.EnumerateFiles(Path.Combine(mod.Path, "Data"), "*.pak"))
            {
                using var pakArchive = ZipFile.OpenRead(pak);
                foreach (var entry in pakArchive.Entries)
                {
                    var entryPath = new ZipPath(entry.FullName);
                    if (entryPath.IsFile &&
                        entryPath.IsWithinFolder(itemFolder) &&
                        entryPath.FileName.StartsWith("InventoryPreset", StringComparison.OrdinalIgnoreCase) &&
                        entryPath.Extension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        var match = Regex.Match(entryPath.FileName, $"(InventoryPreset.*?)__{mod.ModId}.xml", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            var originalPath = new ZipPath(["Libs", "Tables", "item", $"{match.Groups[1]}.xml"]);
                            if (originalItemPresets.ContainsKey(originalPath))
                            {
                                var modFile = DatabaseType.Parse(entry.Open());

                                var originalDatabase = originalItemPresets[originalPath];
                                var workingDatabase = workingItemPresets[originalPath];

                                var difference = originalDatabase.InventoryPresets.Difference(modFile.InventoryPresets);
                                workingDatabase.InventoryPresets.ApplyDifference(difference);

                                Console.WriteLine($"{mod.ModId} - {originalPath.FileName} - {difference.InventoryPreset.Count} Changes");
                            }
                        }
                    }
                }
            }
        }
    }

    static void OutputMerge()
    {
        if (!Directory.Exists(Path.Combine(workingDirectory, "Data")))
            Directory.CreateDirectory(Path.Combine(workingDirectory, "Data"));

        using var zipFile = File.Open(Path.Combine(workingDirectory, "Data", "kcd_two_inventory_preset_merger.pak"), FileMode.Create);
        using var zipArchive = new ZipArchive(zipFile, ZipArchiveMode.Create);
        var serializer = new XmlSerializer(typeof(DatabaseType));

        foreach (var item in originalItemPresets)
        {
            var originalDatabase = item.Value;
            var workingDatabase = workingItemPresets[item.Key];
            var outputDatabase = new DatabaseType();

            var difference = originalDatabase.InventoryPresets.Difference(workingDatabase.InventoryPresets);
            if (difference.InventoryPresetSpecified)
            {
                foreach (var inventoryPreset in difference.InventoryPreset)
                {
                    outputDatabase.InventoryPresets.InventoryPreset.Add(workingDatabase.InventoryPresets.InventoryPreset.First(x => string.Equals(inventoryPreset.Name, x.Name)));
                }

                var zipArchiveEntry = zipArchive.CreateEntry($"Libs/Tables/item/{item.Key.FileNameWithoutExtension}__kcd_two_inventory_preset_merger.xml");
                using var stream = zipArchiveEntry.Open();
                serializer.Serialize(stream, outputDatabase);
            }
        }

        Console.WriteLine("Created kcd_two_inventory_preset_merger.pak");
    }
}
