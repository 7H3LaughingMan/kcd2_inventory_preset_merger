using System.Xml.Serialization;

public partial class InventoryPresetRefType : ICloneable
{
    public InventoryPresetRefType() { }

    public InventoryPresetRefType(string Name = null,
        float? CombatLevel = null,
        float? Weight = null,
        int? Amount = null,
        string ItemClassId = null,
        float? Health = null,
        float? HealthVariation = null)
    {
        this.Name = Name;

        if (CombatLevel.HasValue)
        {
            this.CombatLevel = CombatLevel.Value;
            CombatLevelSpecified = true;
        }

        if (Weight.HasValue)
        {
            this.Weight = Weight.Value;
            WeightSpecified = true;
        }

        if (Amount.HasValue)
        {
            this.Amount = Amount.Value;
            AmountSpecified = true;
        }

        this.ItemClassId = ItemClassId;

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
    }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("CombatLevel")]
    public float CombatLevel { get; set; }

    [XmlIgnore]
    public bool CombatLevelSpecified { get; set; }

    [XmlAttribute("Weight")]
    public float Weight { get; set; }

    [XmlIgnore]
    public bool WeightSpecified { get; set; }

    [XmlAttribute("Amount")]
    public int Amount { get; set; }

    [XmlIgnore]
    public bool AmountSpecified { get; set; }

    [XmlAttribute("ItemClassId")]
    public string ItemClassId { get; set; }

    [XmlAttribute("Health")]
    public float Health { get; set; }

    [XmlIgnore]
    public bool HealthSpecified { get; set; }

    [XmlAttribute("HealthVariation")]
    public float HealthVariation { get; set; }

    [XmlIgnore]
    public bool HealthVariationSpecified { get; set; }

    public override string ToString()
    {
        var header = "InventoryPresetRef";

        if (!string.IsNullOrEmpty(Name))
            header += $" Name:{Name}";

        if (CombatLevelSpecified)
            header += $" CombatLevel:{CombatLevel}";

        if (WeightSpecified)
            header += $" Weight:{Weight}";

        if (AmountSpecified)
            header += $" Amount:{Amount}";

        if (!string.IsNullOrEmpty(ItemClassId))
            header += $" ItemClassId:{ItemClassId}";

        if (HealthSpecified)
            header += $" Health:{Health}";

        if (HealthVariationSpecified)
            header += $" HealthVariation:{HealthVariation}";

        return header;
    }

    public override int GetHashCode() => (Name, CombatLevel, CombatLevelSpecified, Weight, WeightSpecified, Amount, AmountSpecified, ItemClassId, Health, HealthSpecified, HealthVariation, HealthVariationSpecified).GetHashCode();

    public override bool Equals(object obj) => Equals(obj as InventoryPresetRefType);

    public bool Equals(InventoryPresetRefType obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;

        return string.Equals(Name, obj.Name) &&
            (CombatLevel == obj.CombatLevel) && (CombatLevelSpecified == obj.CombatLevelSpecified) &&
            (Weight == obj.Weight) && (WeightSpecified == obj.WeightSpecified) &&
            (Amount == obj.Amount) && (AmountSpecified == obj.AmountSpecified) &&
            string.Equals(ItemClassId, obj.ItemClassId) &&
            (Health == obj.Health) && (HealthSpecified == obj.HealthSpecified) &&
            (HealthVariation == obj.HealthVariation) && (HealthVariationSpecified == obj.HealthVariationSpecified);
    }

    public object Clone()
    {
        return new InventoryPresetRefType
        {
            Name = (Name is null) ? null : $"{Name}",
            CombatLevel = CombatLevel,
            CombatLevelSpecified = CombatLevelSpecified,
            Weight = Weight,
            WeightSpecified = WeightSpecified,
            Amount = Amount,
            AmountSpecified = AmountSpecified,
            ItemClassId = (ItemClassId is null) ? null : $"{ItemClassId}",
            Health = Health,
            HealthSpecified = HealthSpecified,
            HealthVariation = HealthVariation,
            HealthVariationSpecified = HealthVariationSpecified
        };
    }

    public InventoryPresetRefType Difference(InventoryPresetRefType obj)
    {
        var inventoryPresetRef = new InventoryPresetRefType { Name = Name };

        if (CombatLevelSpecified && obj.CombatLevelSpecified)
        {
            if (CombatLevel != obj.CombatLevel)
            {
                inventoryPresetRef.CombatLevel = obj.CombatLevel;
                inventoryPresetRef.CombatLevelSpecified = true;
            }
        }
        else if (obj.CombatLevelSpecified)
        {
            inventoryPresetRef.CombatLevel = obj.CombatLevel;
            inventoryPresetRef.CombatLevelSpecified = true;
        }

        if (WeightSpecified && obj.WeightSpecified)
        {
            if (Weight != obj.Weight)
            {
                inventoryPresetRef.Weight = obj.Weight;
                inventoryPresetRef.WeightSpecified = true;
            }
        }
        else if (obj.WeightSpecified)
        {
            inventoryPresetRef.Weight = obj.Weight;
            inventoryPresetRef.WeightSpecified = true;
        }

        if (AmountSpecified && obj.AmountSpecified)
        {
            if (Amount != obj.Amount)
            {
                inventoryPresetRef.Amount = obj.Amount;
                inventoryPresetRef.AmountSpecified = true;
            }
        }
        else if (obj.AmountSpecified)
        {
            inventoryPresetRef.Amount = obj.Amount;
            inventoryPresetRef.AmountSpecified = true;
        }

        if (!string.Equals(ItemClassId, obj.ItemClassId))
            inventoryPresetRef.ItemClassId = (obj.ItemClassId is null) ? null : $"{obj.ItemClassId}";

        if (HealthSpecified && obj.HealthSpecified)
        {
            if (Health != obj.Health)
            {
                inventoryPresetRef.Health = obj.Health;
                inventoryPresetRef.HealthSpecified = true;
            }
        }
        else if (obj.HealthSpecified)
        {
            inventoryPresetRef.Health = obj.Health;
            inventoryPresetRef.HealthSpecified = true;
        }

        if (HealthVariationSpecified && obj.HealthVariationSpecified)
        {
            if (HealthVariation != obj.HealthVariation)
            {
                inventoryPresetRef.HealthVariation = obj.HealthVariation;
                inventoryPresetRef.HealthVariationSpecified = true;
            }
        }
        else if (obj.HealthVariationSpecified)
        {
            inventoryPresetRef.HealthVariation = obj.HealthVariation;
            inventoryPresetRef.HealthVariationSpecified = true;
        }

        return inventoryPresetRef;
    }

    public void ApplyDifference(InventoryPresetRefType obj)
    {
        if (obj.CombatLevelSpecified)
        {
            CombatLevel = obj.CombatLevel;
            CombatLevelSpecified = obj.CombatLevelSpecified;
        }

        if (obj.WeightSpecified)
        {
            Weight = obj.Weight;
            WeightSpecified = obj.WeightSpecified;
        }

        if (obj.AmountSpecified)
        {
            Amount = obj.Amount;
            AmountSpecified = obj.AmountSpecified;
        }

        if (obj.ItemClassId is not null)
            ItemClassId = $"{obj.ItemClassId}";

        if (obj.HealthSpecified)
        {
            Health = obj.Health;
            HealthSpecified = obj.HealthSpecified;
        }

        if (obj.HealthVariationSpecified)
        {
            HealthVariation = obj.HealthVariation;
            HealthVariationSpecified = obj.HealthVariationSpecified;
        }
    }

    public static bool operator ==(InventoryPresetRefType lhs, InventoryPresetRefType rhs)
    {
        if (lhs is null && rhs is null) return true;
        if (lhs is null || rhs is null) return false;
        return lhs.Equals(rhs);
    }

    public static bool operator !=(InventoryPresetRefType lhs, InventoryPresetRefType rhs) => !(lhs == rhs);
}