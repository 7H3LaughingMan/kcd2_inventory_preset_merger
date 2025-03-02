using System.Xml.Schema;
using System.Xml.Serialization;

[XmlRoot("database")]
public partial class DatabaseType : ICloneable
{
    public static DatabaseType Parse(Stream fileStream)
    {
        var serializer = new XmlSerializer(typeof(DatabaseType));
        return serializer.Deserialize(fileStream) as DatabaseType;
    }

    [XmlElement("InventoryPresets")]
    public InventoryPresetsType InventoryPresets { get; set; } = new InventoryPresetsType();

    [XmlAttribute("name")]
    public string Name { get; set; } = "barbora";

    [XmlAttribute("noNamespaceSchemaLocation", Namespace = XmlSchema.InstanceNamespace)]
    public string SchemaLocation { get; set; } = "InventoryPreset.xsd";

    public override string ToString()
    {
        var lines = new List<string> { $"Database Name:{Name}" };

        foreach (var line in InventoryPresets.ToString().Split(Environment.NewLine))
            lines.Add($"  {line}");

        return string.Join(Environment.NewLine, lines);
    }

    public object Clone()
    {
        return new DatabaseType
        {
            InventoryPresets = InventoryPresets.Clone() as InventoryPresetsType,
            Name = Name,
            SchemaLocation = SchemaLocation
        };
    }
}