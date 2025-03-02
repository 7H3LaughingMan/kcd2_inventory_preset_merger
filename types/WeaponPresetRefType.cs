using System.Xml.Serialization;

public partial class WeaponPresetRefType : ICloneable
{
    public WeaponPresetRefType() { }

    public WeaponPresetRefType(string Name = null,
        float? Weight = null,
        float? CombatLevel = null,
        int? Amount = null,
        string ItemClassId = null,
        float? Health = null,
        float? HealthVariation = null)
    {
        this.Name = Name;

        if (Weight.HasValue)
        {
            this.Weight = Weight.Value;
            WeightSpecified = true;
        }

        if (CombatLevel.HasValue)
        {
            this.CombatLevel = CombatLevel.Value;
            CombatLevelSpecified = true;
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

    [XmlAttribute("Weight")]
    public float Weight { get; set; }

    [XmlIgnore]
    public bool WeightSpecified { get; set; }

    [XmlAttribute("CombatLevel")]
    public float CombatLevel { get; set; }

    [XmlIgnore]
    public bool CombatLevelSpecified { get; set; }

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
        var header = "WeaponPresetRef";

        if (!string.IsNullOrEmpty(Name))
            header += $" Name:{Name}";

        if (WeightSpecified)
            header += $" Weight:{Weight}";

        if (CombatLevelSpecified)
            header += $" CombatLevel:{CombatLevel}";

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

    public override int GetHashCode() => (Name, Weight, WeightSpecified, CombatLevel, CombatLevelSpecified, Amount, AmountSpecified, ItemClassId, Health, HealthSpecified, HealthVariation, HealthVariationSpecified).GetHashCode();

    public override bool Equals(object obj) => Equals(obj as WeaponPresetRefType);

    public bool Equals(WeaponPresetRefType obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;

        return string.Equals(Name, obj.Name) &&
            (Weight == obj.Weight) && (WeightSpecified == obj.WeightSpecified) &&
            (CombatLevel == obj.CombatLevel) && (CombatLevelSpecified == obj.CombatLevelSpecified) &&
            (Amount == obj.Amount) && (AmountSpecified == obj.AmountSpecified) &&
            string.Equals(ItemClassId, obj.ItemClassId) &&
            (Health == obj.Health) && (HealthSpecified == obj.HealthSpecified) &&
            (HealthVariation == obj.HealthVariation) && (HealthVariationSpecified == obj.HealthVariationSpecified);
    }

    public object Clone()
    {
        return new WeaponPresetRefType
        {
            Name = (Name is null) ? null : $"{Name}",
            Weight = Weight,
            WeightSpecified = WeightSpecified,
            CombatLevel = CombatLevel,
            CombatLevelSpecified = CombatLevelSpecified,
            Amount = Amount,
            AmountSpecified = AmountSpecified,
            ItemClassId = (ItemClassId is null) ? null : $"{Name}",
            Health = Health,
            HealthSpecified = HealthSpecified,
            HealthVariation = HealthVariation,
            HealthVariationSpecified = HealthVariationSpecified
        };
    }

    public WeaponPresetRefType Difference(WeaponPresetRefType obj)
    {
        var weaponPresetRef = new WeaponPresetRefType { Name = Name };

        if (WeightSpecified && obj.WeightSpecified)
        {
            if (Weight != obj.Weight)
            {
                weaponPresetRef.Weight = obj.Weight;
                weaponPresetRef.WeightSpecified = true;
            }
        }
        else if (obj.WeightSpecified)
        {
            weaponPresetRef.Weight = obj.Weight;
            weaponPresetRef.WeightSpecified = true;
        }

        if (CombatLevelSpecified && obj.CombatLevelSpecified)
        {
            if (CombatLevel != obj.CombatLevel)
            {
                weaponPresetRef.CombatLevel = obj.CombatLevel;
                weaponPresetRef.CombatLevelSpecified = true;
            }
        }
        else if (obj.CombatLevelSpecified)
        {
            weaponPresetRef.CombatLevel = obj.CombatLevel;
            weaponPresetRef.CombatLevelSpecified = true;
        }

        if (AmountSpecified && obj.AmountSpecified)
        {
            if (Amount != obj.Amount)
            {
                weaponPresetRef.Amount = obj.Amount;
                weaponPresetRef.AmountSpecified = true;
            }
        }
        else if (obj.AmountSpecified)
        {
            weaponPresetRef.Amount = obj.Amount;
            weaponPresetRef.AmountSpecified = true;
        }

        if (!string.Equals(ItemClassId, obj.ItemClassId))
            weaponPresetRef.ItemClassId = (obj.ItemClassId is null) ? null : $"{obj.ItemClassId}";

        if (HealthSpecified && obj.HealthSpecified)
        {
            if (Health != obj.Health)
            {
                weaponPresetRef.Health = obj.Health;
                weaponPresetRef.HealthSpecified = true;
            }
        }
        else if (obj.HealthSpecified)
        {
            weaponPresetRef.Health = obj.Health;
            weaponPresetRef.HealthSpecified = true;
        }

        if (HealthVariationSpecified && obj.HealthVariationSpecified)
        {
            if (HealthVariation != obj.HealthVariation)
            {
                weaponPresetRef.HealthVariation = obj.HealthVariation;
                weaponPresetRef.HealthVariationSpecified = true;
            }
        }
        else if (obj.HealthVariationSpecified)
        {
            weaponPresetRef.HealthVariation = obj.HealthVariation;
            weaponPresetRef.HealthVariationSpecified = true;
        }

        return weaponPresetRef;
    }

    public void ApplyDifference(WeaponPresetRefType obj)
    {
        if (obj.WeightSpecified)
        {
            Weight = obj.Weight;
            WeightSpecified = obj.WeightSpecified;
        }

        if (obj.CombatLevelSpecified)
        {
            CombatLevel = obj.CombatLevel;
            CombatLevelSpecified = obj.CombatLevelSpecified;
        }

        if (obj.AmountSpecified)
        {
            Amount = obj.Amount;
            AmountSpecified = obj.AmountSpecified;
        }

        if(obj.ItemClassId is not null)
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

    public static bool operator ==(WeaponPresetRefType lhs, WeaponPresetRefType rhs)
    {
        if (lhs is null && rhs is null) return true;
        if (lhs is null || rhs is null) return false;
        return lhs.Equals(rhs);
    }

    public static bool operator !=(WeaponPresetRefType lhs, WeaponPresetRefType rhs) => !(lhs == rhs);
}