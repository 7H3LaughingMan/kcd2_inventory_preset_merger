using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Xml.Serialization;

public partial class InventoryPresetsType : ICloneable
{
    public InventoryPresetsType() { }

    public InventoryPresetsType(InventoryPresetType[] InventoryPresets) => InventoryPreset = [.. InventoryPresets];

    [XmlElement("InventoryPreset")]
    public Collection<InventoryPresetType> InventoryPreset { get; set; } = [];

    [XmlIgnore]
    public bool InventoryPresetSpecified => InventoryPreset.Count != 0;

    [XmlAttribute("version")]
    public string Version { get; set; } = "2";

    public override string ToString()
    {
        var lines = new List<string> { $"InventoryPresets Version:{Version}" };

        foreach (var inventoryPreset in InventoryPreset)
            foreach (var line in inventoryPreset.ToString().Split(Environment.NewLine))
                lines.Add($"  {line}");

        return string.Join(Environment.NewLine, lines);
    }

    public InventoryPresetsType Difference(InventoryPresetsType obj)
    {
        var inventoryPresets = new InventoryPresetsType();

        foreach (var item in InventoryPreset)
        {
            var candidate = obj.InventoryPreset.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null && item != candidate)
                inventoryPresets.InventoryPreset.Add(item.Difference(candidate));
        }

        foreach (var item in obj.InventoryPreset)
        {
            var candidate = InventoryPreset.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is null)
                inventoryPresets.InventoryPreset.Add(item.Clone() as InventoryPresetType);
        }

        return inventoryPresets;
    }

    public void ApplyDifference(InventoryPresetsType obj)
    {
        foreach (var item in obj.InventoryPreset)
        {
            var candidate = InventoryPreset.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
                candidate.ApplyDifference(item);
            else
                InventoryPreset.Add(item.Clone() as InventoryPresetType);
        }
    }

    public object Clone()
    {
        return new InventoryPresetsType
        {
            InventoryPreset = [.. InventoryPreset.Select(inventoryPreset => inventoryPreset.Clone() as InventoryPresetType).ToList()],
            Version = Version
        };
    }
}