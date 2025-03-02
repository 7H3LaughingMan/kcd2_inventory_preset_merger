using System.Xml.Serialization;

[XmlRoot("kcd_mod")]
public partial class KCD_Mod
{
    public static KCD_Mod Parse(string path)
    {
        if (!File.Exists(path))
            return new KCD_Mod { Path = Directory.GetParent(path).FullName };

        var serializer = new XmlSerializer(typeof(KCD_Mod));
        var fileStream = File.OpenRead(path);

        var mod = serializer.Deserialize(fileStream) as KCD_Mod;
        mod.Path = Directory.GetParent(path).FullName;

        return mod;
    }

    [XmlElement("info")]
    public Mod_Info Info { get; set; }

    [XmlElement("supports")]
    public Mod_Supports Supports { get; set; }

    [XmlIgnore]
    public string Path { get; set; }

    public string ModId
    {
        get
        {
            if (Info?.ModID is not null) return Info.ModID;
            if (Info?.Name is not null) return Info.Name.ToLower().Replace(' ', '_');
            return System.IO.Path.GetFileName(Path).ToLower().Replace(' ', '_');
        }
    }

    public override string ToString()
    {
        var lines = new List<string>
        {
            "KCD Mod",
            $"  Path - {Path}",
            $"  Mod ID - {ModId}"
        };

        if (Info is not null)
            lines.AddRange(Info.ToString().Split(Environment.NewLine));

        if (Supports is not null)
            lines.AddRange(Supports.ToString().Split(Environment.NewLine));

        return string.Join(Environment.NewLine, lines);
    }
}

public partial class Mod_Info
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("modid")]
    public string ModID { get; set; }

    [XmlElement("description")]
    public string Description { get; set; }

    [XmlElement("author")]
    public string Author { get; set; }

    [XmlElement("version")]
    public string Version { get; set; }

    [XmlElement("created_on")]
    public string CreatedOn { get; set; }

    [XmlArray("dependencies")]
    [XmlArrayItem("req_mod")]
    public List<string> RequiredMods { get; set; }

    [XmlIgnore]
    public bool RequiredModsSpecified => RequiredMods.Count != 0;

    public override string ToString()
    {
        var lines = new List<string> { "  Info" };

        if (!string.IsNullOrWhiteSpace(Name))
            lines.Add($"    Name - {Name}");

        if (!string.IsNullOrWhiteSpace(ModID))
            lines.Add($"    Mod ID - {ModID}");

        if (!string.IsNullOrWhiteSpace(Description))
            lines.Add($"    Description - {Description}");

        if (!string.IsNullOrWhiteSpace(Author))
            lines.Add($"    Author - {Author}");

        if (!string.IsNullOrWhiteSpace(Version))
            lines.Add($"    Version - {Version}");

        if (!string.IsNullOrWhiteSpace(CreatedOn))
            lines.Add($"    Created On - {CreatedOn}");

        if (RequiredModsSpecified)
        {
            lines.Add($"    Dependencies");
            lines.AddRange(RequiredMods.Select(x => $"      {x}"));
        }

        return string.Join(Environment.NewLine, lines);
    }
}

public partial class Mod_Supports
{
    [XmlElement("kcd_version")]
    public string KCD_Version { get; set; }

    public override string ToString()
    {
        var lines = new List<string> { "  Supports" };

        if (KCD_Version is not null)
            lines.Add($"    KCD Version - {KCD_Version}");

        return string.Join(Environment.NewLine, lines);
    }
}