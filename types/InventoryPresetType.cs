using System.Collections.ObjectModel;
using System.Xml.Serialization;

public partial class InventoryPresetType : ICloneable
{
    public InventoryPresetType() { }

    public InventoryPresetType(PresetItemType[] PresetItemTypes = null,
        InventoryPresetRefType[] InventoryPresetRefTypes = null,
        ClothingPresetRefType[] ClothingPresetRefTypes = null,
        WeaponPresetRefType[] WeaponPresetRefTypes = null,
        string Name = null,
        string Mode = null,
        string ModeValue = null,
        string ModeValueVariation = null,
        float? Health = null,
        float? HealthVariation = null,
        int? Amount = null,
        int? AmountCount = null,
        int? AmountVariation = null)
    {
        if (PresetItemTypes != null)
            PresetItem = [.. PresetItemTypes];

        if (InventoryPresetRefTypes != null)
            InventoryPresetRef = [.. InventoryPresetRefTypes];

        if (ClothingPresetRefTypes != null)
            ClothingPresetRef = [.. ClothingPresetRefTypes];

        if (WeaponPresetRefTypes != null)
            WeaponPresetRef = [.. WeaponPresetRefTypes];

        this.Name = Name;
        this.Mode = Mode;
        this.ModeValue = ModeValue;
        this.ModeValueVariation = ModeValueVariation;

        if (Health.HasValue)
        {
            this.Health = Health.Value;
            HealthSpecified = true;
        }

        if (HealthVariation.HasValue)
        {
            this.HealthVariation = HealthVariation.Value;
            HealthVariationSpecified = true;
        }

        if (Amount.HasValue)
        {
            this.Amount = Amount.Value;
            AmountSpecified = true;
        }

        if (AmountCount.HasValue)
        {
            this.AmountCount = AmountCount.Value;
            AmountCountSpecified = true;
        }

        if (AmountVariation.HasValue)
        {
            this.AmountVariation = AmountVariation.Value;
            AmountVariationSpecified = true;
        }
    }

    [XmlElement("PresetItem")]
    public Collection<PresetItemType> PresetItem { get; set; } = [];

    [XmlIgnore]
    public bool PresetItemSpecified => PresetItem.Count != 0;

    [XmlElement("InventoryPresetRef")]
    public Collection<InventoryPresetRefType> InventoryPresetRef { get; set; } = [];

    [XmlIgnore]
    public bool InventoryPresetRefSpecified => InventoryPresetRef.Count != 0;

    [XmlElement("ClothingPresetRef")]
    public Collection<ClothingPresetRefType> ClothingPresetRef { get; set; } = [];

    [XmlIgnore]
    public bool ClothingPresetRefSpecified => ClothingPresetRef.Count != 0;

    [XmlElement("WeaponPresetRef")]
    public Collection<WeaponPresetRefType> WeaponPresetRef { get; set; } = [];

    [XmlIgnore]
    public bool WeaponPresetRefSpecified => WeaponPresetRef.Count != 0;

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("Mode")]
    public string Mode { get; set; }

    [XmlAttribute("ModeValue")]
    public string ModeValue { get; set; }

    [XmlAttribute("ModeValueVariation")]
    public string ModeValueVariation { get; set; }

    [XmlAttribute("Health")]
    public float Health { get; set; }

    [XmlIgnore]
    public bool HealthSpecified { get; set; }

    [XmlAttribute("HealthVariation")]
    public float HealthVariation { get; set; }

    [XmlIgnore]
    public bool HealthVariationSpecified { get; set; }

    [XmlAttribute("Amount")]
    public int Amount { get; set; }

    [XmlIgnore]
    public bool AmountSpecified { get; set; }

    [XmlAttribute("AmountCount")]
    public int AmountCount { get; set; }

    [XmlIgnore]
    public bool AmountCountSpecified { get; set; }

    [XmlAttribute("AmountVariation")]
    public int AmountVariation { get; set; }

    [XmlIgnore]
    public bool AmountVariationSpecified { get; set; }

    public override string ToString()
    {
        var header = "InventoryPreset";

        if (!string.IsNullOrEmpty(Name))
            header += $" Name:{Name}";

        if (!string.IsNullOrEmpty(Mode))
            header += $" Mode:{Mode}";

        if (!string.IsNullOrEmpty(ModeValue))
            header += $" ModeValue:{ModeValue}";

        if (!string.IsNullOrEmpty(ModeValueVariation))
            header += $" ModeValueVariation:{ModeValueVariation}";

        if (HealthSpecified)
            header += $" Health:{Health}";

        if (HealthVariationSpecified)
            header += $" HealthVariation:{HealthVariation}";

        if (AmountSpecified)
            header += $" Amount:{Amount}";

        if (AmountCountSpecified)
            header += $" AmountCount:{AmountCount}";

        if (AmountVariationSpecified)
            header += $" AmountVariation:{AmountVariation}";

        var lines = new List<string> { header };

        foreach (var presetItem in PresetItem)
            foreach (var line in presetItem.ToString().Split(Environment.NewLine))
                lines.Add($"  {line}");

        foreach (var inventoryPresetRef in InventoryPresetRef)
            foreach (var line in inventoryPresetRef.ToString().Split(Environment.NewLine))
                lines.Add($"  {line}");

        foreach (var clothingPresetRef in ClothingPresetRef)
            foreach (var line in clothingPresetRef.ToString().Split(Environment.NewLine))
                lines.Add($"  {line}");

        foreach (var weaponPresetRef in WeaponPresetRef)
            foreach (var line in weaponPresetRef.ToString().Split(Environment.NewLine))
                lines.Add($"  {line}");

        return string.Join(Environment.NewLine, lines);
    }

    public override int GetHashCode() => (PresetItem, InventoryPresetRef, ClothingPresetRef, WeaponPresetRef, Name, Mode, ModeValue, ModeValueVariation, Health, HealthSpecified, HealthVariation, HealthVariationSpecified, Amount, AmountSpecified, AmountCount, AmountCountSpecified, AmountVariation, AmountVariationSpecified).GetHashCode();

    public override bool Equals(object obj) => Equals(obj as InventoryPresetType);

    public bool Equals(InventoryPresetType obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;

        var presetItems = new HashSet<PresetItemType>(PresetItem);
        var inventoryPresetRefs = new HashSet<InventoryPresetRefType>(InventoryPresetRef);
        var clothingPresetRefs = new HashSet<ClothingPresetRefType>(ClothingPresetRef);
        var weaponPresetRefs = new HashSet<WeaponPresetRefType>(WeaponPresetRef);

        return presetItems.SetEquals(obj.PresetItem) &&
            inventoryPresetRefs.SetEquals(obj.InventoryPresetRef) &&
            clothingPresetRefs.SetEquals(obj.ClothingPresetRef) &&
            weaponPresetRefs.SetEquals(obj.WeaponPresetRef) &&
            string.Equals(Name, obj.Name) &&
            string.Equals(Mode, obj.Mode) &&
            string.Equals(ModeValue, obj.ModeValue) &&
            string.Equals(ModeValueVariation, obj.ModeValueVariation) &&
            (Health == obj.Health) && (HealthSpecified == obj.HealthSpecified) &&
            (HealthVariation == obj.HealthVariation) && (HealthVariationSpecified == obj.HealthVariationSpecified) &&
            (Amount == obj.Amount) && (AmountSpecified == obj.AmountSpecified) &&
            (AmountCount == obj.AmountCount) && (AmountCountSpecified == obj.AmountCountSpecified) &&
            (AmountVariation == obj.AmountVariation) && (AmountVariationSpecified == obj.AmountVariationSpecified);
    }

    public object Clone()
    {
        return new InventoryPresetType
        {
            PresetItem = [.. PresetItem.Select(x => x.Clone() as PresetItemType).ToList()],
            InventoryPresetRef = [.. InventoryPresetRef.Select(x => x.Clone() as InventoryPresetRefType).ToList()],
            ClothingPresetRef = [.. ClothingPresetRef.Select(x => x.Clone() as ClothingPresetRefType).ToList()],
            WeaponPresetRef = [.. WeaponPresetRef.Select(x => x.Clone() as WeaponPresetRefType).ToList()],
            Name = Name,
            Mode = Mode,
            ModeValue = ModeValue,
            ModeValueVariation = ModeValueVariation,
            Health = Health,
            HealthSpecified = HealthSpecified,
            HealthVariation = HealthVariation,
            HealthVariationSpecified = HealthVariationSpecified,
            Amount = Amount,
            AmountSpecified = AmountSpecified,
            AmountCount = AmountCount,
            AmountCountSpecified = AmountCountSpecified,
            AmountVariation = AmountVariation,
            AmountVariationSpecified = AmountVariationSpecified
        };
    }

    public InventoryPresetType Difference(InventoryPresetType obj)
    {
        var inventoryPreset = new InventoryPresetType { Name = Name };

        var presetItems = new Collection<PresetItemType>();

        foreach (var item in PresetItem)
        {
            var candidate = obj.PresetItem.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
            {
                if (item != candidate)
                {
                    presetItems.Add(item.Difference(candidate));
                }
            }
        }

        foreach (var item in obj.PresetItem)
        {
            var candidate = PresetItem.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is null)
            {
                presetItems.Add(item.Clone() as PresetItemType);
            }
        }

        inventoryPreset.PresetItem = presetItems;

        var inventoryPresetRefTypes = new Collection<InventoryPresetRefType>();

        foreach (var item in InventoryPresetRef)
        {
            var candidate = obj.InventoryPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
            {
                if (item != candidate)
                {
                    inventoryPresetRefTypes.Add(item.Difference(candidate));
                }
            }
        }

        foreach (var item in obj.InventoryPresetRef)
        {
            var candidate = InventoryPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is null)
            {
                inventoryPresetRefTypes.Add(item.Clone() as InventoryPresetRefType);
            }
        }

        inventoryPreset.InventoryPresetRef = inventoryPresetRefTypes;

        var clothingPresetRefTypes = new Collection<ClothingPresetRefType>();

        foreach (var item in ClothingPresetRef)
        {
            var candidate = obj.ClothingPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
            {
                if (item != candidate)
                {
                    clothingPresetRefTypes.Add(item.Difference(candidate));
                }
            }
        }

        foreach (var item in obj.ClothingPresetRef)
        {
            var candidate = ClothingPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is null)
            {
                clothingPresetRefTypes.Add(item.Clone() as ClothingPresetRefType);
            }
        }

        inventoryPreset.ClothingPresetRef = clothingPresetRefTypes;

        var weaponPresetRefTypes = new Collection<WeaponPresetRefType>();

        foreach (var item in WeaponPresetRef)
        {
            var candidate = obj.WeaponPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
            {
                if (item != candidate)
                {
                    weaponPresetRefTypes.Add(item.Difference(candidate));
                }
            }
        }

        foreach (var item in obj.WeaponPresetRef)
        {
            var candidate = WeaponPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is null)
            {
                weaponPresetRefTypes.Add(item.Clone() as WeaponPresetRefType);
            }
        }

        inventoryPreset.WeaponPresetRef = weaponPresetRefTypes;

        if (!string.Equals(Mode, obj.Mode))
            inventoryPreset.Mode = (obj.Mode is null) ? null : $"{obj.Mode}";

        if (!string.Equals(ModeValue, obj.ModeValue))
            inventoryPreset.ModeValue = (obj.ModeValue is null) ? null : $"{obj.ModeValue}";

        if (!string.Equals(ModeValueVariation, obj.ModeValueVariation))
            inventoryPreset.ModeValueVariation = (obj.ModeValueVariation is null) ? null : $"{obj.ModeValueVariation}";

        if (HealthSpecified && obj.HealthSpecified)
        {
            if (Health != obj.Health)
            {
                inventoryPreset.Health = obj.Health;
                inventoryPreset.HealthSpecified = true;
            }
        }
        else if (obj.HealthSpecified)
        {
            inventoryPreset.Health = obj.Health;
            inventoryPreset.HealthSpecified = true;
        }

        if (HealthVariationSpecified && obj.HealthVariationSpecified)
        {
            if (HealthVariation != obj.HealthVariation)
            {
                inventoryPreset.HealthVariation = obj.HealthVariation;
                inventoryPreset.HealthVariationSpecified = true;
            }
        }
        else if (obj.HealthVariationSpecified)
        {
            inventoryPreset.HealthVariation = obj.HealthVariation;
            inventoryPreset.HealthVariationSpecified = true;
        }

        if (AmountSpecified && obj.AmountSpecified)
        {
            if (Amount != obj.Amount)
            {
                inventoryPreset.Amount = obj.Amount;
                inventoryPreset.AmountSpecified = true;
            }
        }
        else if (obj.AmountSpecified)
        {
            inventoryPreset.Amount = obj.Amount;
            inventoryPreset.AmountSpecified = true;
        }

        if (AmountCountSpecified && obj.AmountCountSpecified)
        {
            if (AmountCount != obj.AmountCount)
            {
                inventoryPreset.AmountCount = obj.AmountCount;
                inventoryPreset.AmountCountSpecified = true;
            }
        }
        else if (obj.AmountCountSpecified)
        {
            inventoryPreset.AmountCount = obj.AmountCount;
            inventoryPreset.AmountCountSpecified = true;
        }

        if (AmountVariationSpecified && obj.AmountVariationSpecified)
        {
            if (AmountVariation != obj.AmountVariation)
            {
                inventoryPreset.AmountVariation = obj.AmountVariation;
                inventoryPreset.AmountVariationSpecified = true;
            }
        }
        else if (obj.AmountVariationSpecified)
        {
            inventoryPreset.AmountVariation = obj.AmountVariation;
            inventoryPreset.AmountVariationSpecified = true;
        }

        return inventoryPreset;
    }

    public void ApplyDifference(InventoryPresetType obj)
    {
        foreach (var item in obj.PresetItem)
        {
            var candidate = PresetItem.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
                candidate.ApplyDifference(item);
            else
                PresetItem.Add(item.Clone() as PresetItemType);
        }

        foreach (var item in obj.InventoryPresetRef)
        {
            var candidate = InventoryPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
                candidate.ApplyDifference(item);
            else
                InventoryPresetRef.Add(item.Clone() as InventoryPresetRefType);
        }

        foreach (var item in obj.ClothingPresetRef)
        {
            var candidate = ClothingPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
                candidate.ApplyDifference(item);
            else
                ClothingPresetRef.Add(item.Clone() as ClothingPresetRefType);
        }

        foreach (var item in obj.WeaponPresetRef)
        {
            var candidate = WeaponPresetRef.FirstOrDefault(x => string.Equals(item.Name, x.Name), null);
            if (candidate is not null)
                candidate.ApplyDifference(item);
            else
                WeaponPresetRef.Add(item.Clone() as WeaponPresetRefType);
        }

        if (obj.Mode is not null)
            Mode = $"{obj.Mode}";

        if (obj.ModeValue is not null)
            ModeValue = $"{obj.ModeValue}";

        if (obj.ModeValueVariation is not null)
            ModeValueVariation = $"{obj.ModeValueVariation}";

        if (obj.HealthSpecified)
            Health = obj.Health;

        if (obj.HealthVariationSpecified)
            HealthVariation = obj.HealthVariation;

        if (obj.AmountSpecified)
            Amount = obj.Amount;

        if (obj.AmountCountSpecified)
            AmountCount = obj.AmountCount;

        if (obj.AmountVariationSpecified)
            AmountVariationSpecified = obj.AmountVariationSpecified;
    }

    public static bool operator ==(InventoryPresetType lhs, InventoryPresetType rhs)
    {
        if (lhs is null && rhs is null) return true;
        if (lhs is null || rhs is null) return false;
        return lhs.Equals(rhs);
    }

    public static bool operator !=(InventoryPresetType lhs, InventoryPresetType rhs) => !(lhs == rhs);
}