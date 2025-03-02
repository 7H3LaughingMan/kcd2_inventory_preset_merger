using System.Xml.Serialization;

public partial class ClothingPresetRefType : ICloneable
{
    public ClothingPresetRefType() { }

    public ClothingPresetRefType(string Name = null,
        float? Weight = null,
        float? CombatLevel = null,
        int? Amount = null,
        float? Health = null)
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

        if (Health.HasValue)
        {
            this.Health = Health.Value;
            HealthSpecified = true;
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

    [XmlAttribute("Health")]
    public float Health { get; set; }

    [XmlIgnore]
    public bool HealthSpecified { get; set; }

    public override string ToString()
    {
        var header = "ClothingPresetRef";

        if (!string.IsNullOrEmpty(Name))
            header += $" Name:{Name}";

        if (WeightSpecified)
            header += $" Weight:{Weight}";

        if (CombatLevelSpecified)
            header += $" CombatLevel:{CombatLevel}";

        if (AmountSpecified)
            header += $" Amount:{Amount}";

        if (HealthSpecified)
            header += $" Health:{Health}";

        return header;
    }

    public override int GetHashCode() => (Name, Weight, WeightSpecified, CombatLevel, CombatLevelSpecified, Amount, AmountSpecified, Health, HealthSpecified).GetHashCode();

    public override bool Equals(object obj) => Equals(obj as ClothingPresetRefType);

    public bool Equals(ClothingPresetRefType obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;

        return string.Equals(Name, obj.Name) &&
            (Weight == obj.Weight) && (WeightSpecified == obj.WeightSpecified) &&
            (CombatLevel == obj.CombatLevel) && (CombatLevelSpecified == obj.CombatLevelSpecified) &&
            (Amount == obj.Amount) && (AmountSpecified == obj.AmountSpecified) &&
            (Health == obj.Health) && (HealthSpecified == obj.HealthSpecified);
    }

    public object Clone()
    {
        return new ClothingPresetRefType
        {
            Name = (Name is null) ? null : $"{Name}",
            Weight = Weight,
            WeightSpecified = WeightSpecified,
            CombatLevel = CombatLevel,
            CombatLevelSpecified = CombatLevelSpecified,
            Amount = Amount,
            AmountSpecified = AmountSpecified,
            Health = Health,
            HealthSpecified = HealthSpecified
        };
    }

    public ClothingPresetRefType Difference(ClothingPresetRefType obj)
    {
        var clothingPresetRef = new ClothingPresetRefType { Name = Name };

        if (WeightSpecified && obj.WeightSpecified)
        {
            if (Weight != obj.Weight)
            {
                clothingPresetRef.Weight = obj.Weight;
                clothingPresetRef.WeightSpecified = true;
            }
        }
        else if (obj.WeightSpecified)
        {
            clothingPresetRef.Weight = obj.Weight;
            clothingPresetRef.WeightSpecified = true;
        }

        if (CombatLevelSpecified && obj.CombatLevelSpecified)
        {
            if (CombatLevel != obj.CombatLevel)
            {
                clothingPresetRef.CombatLevel = obj.CombatLevel;
                clothingPresetRef.CombatLevelSpecified = true;
            }
        }
        else if (obj.CombatLevelSpecified)
        {
            clothingPresetRef.CombatLevel = obj.CombatLevel;
            clothingPresetRef.CombatLevelSpecified = true;
        }

        if (AmountSpecified && obj.AmountSpecified)
        {
            if (Amount != obj.Amount)
            {
                clothingPresetRef.Amount = obj.Amount;
                clothingPresetRef.AmountSpecified = true;
            }
        }
        else if (obj.AmountSpecified)
        {
            clothingPresetRef.Amount = obj.Amount;
            clothingPresetRef.AmountSpecified = true;
        }

        if (HealthSpecified && obj.HealthSpecified)
        {
            if (Health != obj.Health)
            {
                clothingPresetRef.Health = obj.Health;
                clothingPresetRef.HealthSpecified = true;
            }
        }
        else if (obj.HealthSpecified)
        {
            clothingPresetRef.Health = obj.Health;
            clothingPresetRef.HealthSpecified = true;
        }

        return clothingPresetRef;
    }

    public void ApplyDifference(ClothingPresetRefType obj)
    {
        if (obj.WeightSpecified)
        {
            Weight = obj.Weight;
            WeightSpecified = obj.WeightSpecified;
        }

        if (CombatLevelSpecified && obj.CombatLevelSpecified)
        {
            CombatLevel = obj.CombatLevel;
            CombatLevelSpecified = obj.CombatLevelSpecified;
        }

        if (AmountSpecified && obj.AmountSpecified)
        {
            Amount = obj.Amount;
            AmountSpecified = obj.AmountSpecified;
        }

        if (HealthSpecified && obj.HealthSpecified)
        {
            Health = obj.Health;
            HealthSpecified = obj.HealthSpecified;
        }
    }

    public static bool operator ==(ClothingPresetRefType lhs, ClothingPresetRefType rhs)
    {
        if (lhs is null && rhs is null) return true;
        if (lhs is null || rhs is null) return false;
        return lhs.Equals(rhs);
    }

    public static bool operator !=(ClothingPresetRefType lhs, ClothingPresetRefType rhs) => !(lhs == rhs);
}