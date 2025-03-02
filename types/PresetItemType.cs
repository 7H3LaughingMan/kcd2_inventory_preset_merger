using System.Xml.Serialization;

public partial class PresetItemType : ICloneable
{
    public PresetItemType() { }

    public PresetItemType(string Name = null,
        string ItemClassId = null,
        int? Amount = null,
        float? Weight = null,
        float? Health = null,
        float? HealthVariation = null,
        float? Quality = null,
        float? Condition = null,
        float? ConditionVariation = null)
    {
        this.Name = Name;
        this.ItemClassId = ItemClassId;

        if (Amount.HasValue)
        {
            this.Amount = Amount.Value;
            AmountSpecified = true;
        }

        if (Weight.HasValue)
        {
            this.Weight = Weight.Value;
            WeightSpecified = true;
        }

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

        if (Quality.HasValue)
        {
            this.Quality = Quality.Value;
            QualitySpecified = true;
        }

        if (Condition.HasValue)
        {
            this.Condition = Condition.Value;
            ConditionSpecified = true;
        }

        if (ConditionVariation.HasValue)
        {
            this.ConditionVariation = ConditionVariation.Value;
            ConditionVariationSpecified = true;
        }
    }

    [XmlAttribute("Name")]
    public string Name { get; set; }

    [XmlAttribute("ItemClassId")]
    public string ItemClassId { get; set; }

    [XmlAttribute("Amount")]
    public int Amount { get; set; }

    [XmlIgnore]
    public bool AmountSpecified { get; set; }

    [XmlAttribute("Weight")]
    public float Weight { get; set; }

    [XmlIgnore]
    public bool WeightSpecified { get; set; }

    [XmlAttribute("Health")]
    public float Health { get; set; }

    [XmlIgnore]
    public bool HealthSpecified { get; set; }

    [XmlAttribute("HealthVariation")]
    public float HealthVariation { get; set; }

    [XmlIgnore]
    public bool HealthVariationSpecified { get; set; }

    [XmlAttribute("Quality")]
    public float Quality { get; set; }

    [XmlIgnore]
    public bool QualitySpecified { get; set; }

    [XmlAttribute("Condition")]
    public float Condition { get; set; }

    [XmlIgnore]
    public bool ConditionSpecified { get; set; }

    [XmlAttribute("ConditionVariation")]
    public float ConditionVariation { get; set; }

    [XmlIgnore]
    public bool ConditionVariationSpecified { get; set; }

    public override string ToString()
    {
        var header = "PresetItem";

        if (!string.IsNullOrEmpty(Name))
            header += $" Name:{Name}";

        if (!string.IsNullOrEmpty(ItemClassId))
            header += $" ItemClassId:{ItemClassId}";

        if (AmountSpecified)
            header += $" Amount:{Amount}";

        if (WeightSpecified)
            header += $" Weight:{Weight}";

        if (HealthSpecified)
            header += $" Health:{Health}";

        if (HealthVariationSpecified)
            header += $" HealthVariation:{HealthVariation}";

        if (QualitySpecified)
            header += $" Quality:{Quality}";

        if (ConditionSpecified)
            header += $" Condition:{Condition}";

        if (ConditionVariationSpecified)
            header += $" ConditionVariation:{ConditionVariation}";

        return header;
    }

    public override int GetHashCode() => (Name, ItemClassId, Amount, AmountSpecified, Weight, WeightSpecified, Health, HealthSpecified, HealthVariation, HealthVariationSpecified, Quality, QualitySpecified, Condition, ConditionSpecified, ConditionVariation, ConditionVariationSpecified).GetHashCode();

    public override bool Equals(object obj) => Equals(obj as PresetItemType);

    public bool Equals(PresetItemType obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;

        return string.Equals(Name, obj.Name) &&
            string.Equals(ItemClassId, obj.ItemClassId) &&
            (Amount == obj.Amount) && (AmountSpecified == obj.AmountSpecified) &&
            (Weight == obj.Weight) && (WeightSpecified == obj.WeightSpecified) &&
            (Health == obj.Health) && (HealthSpecified == obj.HealthSpecified) &&
            (HealthVariation == obj.HealthVariation) && (HealthVariationSpecified == obj.HealthVariationSpecified) &&
            (Quality == obj.Quality) && (QualitySpecified == obj.QualitySpecified) &&
            (Condition == obj.Condition) && (ConditionSpecified == obj.ConditionSpecified) &&
            (ConditionVariation == obj.ConditionVariation) && (ConditionVariationSpecified == obj.ConditionVariationSpecified);
    }

    public object Clone()
    {
        return new PresetItemType
        {
            Name = (Name is null) ? null : $"{Name}",
            ItemClassId = (ItemClassId is null) ? null : $"{ItemClassId}",
            Amount = Amount,
            AmountSpecified = AmountSpecified,
            Weight = Weight,
            WeightSpecified = WeightSpecified,
            Health = Health,
            HealthSpecified = HealthSpecified,
            HealthVariation = HealthVariation,
            HealthVariationSpecified = HealthVariationSpecified,
            Quality = Quality,
            QualitySpecified = QualitySpecified,
            Condition = Condition,
            ConditionSpecified = ConditionSpecified,
            ConditionVariation = ConditionVariation,
            ConditionVariationSpecified = ConditionVariationSpecified
        };
    }

    public PresetItemType Difference(PresetItemType obj)
    {
        var presetItem = new PresetItemType { Name = Name };

        if (!string.Equals(ItemClassId, obj.ItemClassId))
            presetItem.ItemClassId = (obj.ItemClassId is null) ? null : $"{obj.ItemClassId}";

        if (AmountSpecified && obj.AmountSpecified)
        {
            if (Amount != obj.Amount)
            {
                presetItem.Amount = obj.Amount;
                presetItem.AmountSpecified = true;
            }
        }
        else if (obj.AmountSpecified)
        {
            presetItem.Amount = obj.Amount;
            presetItem.AmountSpecified = true;
        }

        if (WeightSpecified && obj.WeightSpecified)
        {
            if (Weight != obj.Weight)
            {
                presetItem.Weight = obj.Weight;
                presetItem.WeightSpecified = true;
            }
        }
        else if (obj.WeightSpecified)
        {
            presetItem.Weight = obj.Weight;
            presetItem.WeightSpecified = true;
        }

        if (HealthSpecified && obj.HealthSpecified)
        {
            if (Health != obj.Health)
            {
                presetItem.Health = obj.Health;
                presetItem.HealthSpecified = true;
            }
        }
        else if (obj.HealthSpecified)
        {
            presetItem.Health = obj.Health;
            presetItem.HealthSpecified = true;
        }

        if (HealthVariationSpecified && obj.HealthVariationSpecified)
        {
            if (HealthVariation != obj.HealthVariation)
            {
                presetItem.HealthVariation = obj.HealthVariation;
                presetItem.HealthVariationSpecified = true;
            }
        }
        else if (obj.HealthVariationSpecified)
        {
            presetItem.HealthVariation = obj.HealthVariation;
            presetItem.HealthVariationSpecified = true;
        }

        if (QualitySpecified && obj.QualitySpecified)
        {
            if (Quality != obj.Quality)
            {
                presetItem.Quality = obj.Quality;
                presetItem.QualitySpecified = true;
            }
        }
        else if (obj.QualitySpecified)
        {
            presetItem.Quality = obj.Quality;
            presetItem.QualitySpecified = true;
        }

        if (ConditionSpecified && obj.ConditionSpecified)
        {
            if (Condition != obj.Condition)
            {
                presetItem.Condition = obj.Condition;
                presetItem.ConditionSpecified = true;
            }
        }
        else if (obj.ConditionSpecified)
        {
            presetItem.Condition = obj.Condition;
            presetItem.ConditionSpecified = true;
        }

        if (ConditionVariationSpecified && obj.ConditionVariationSpecified)
        {
            if (ConditionVariation != obj.ConditionVariation)
            {
                presetItem.ConditionVariation = obj.ConditionVariation;
                presetItem.ConditionVariationSpecified = true;
            }
        }
        else if (obj.ConditionVariationSpecified)
        {
            presetItem.ConditionVariation = obj.ConditionVariation;
            presetItem.ConditionVariationSpecified = true;
        }

        return presetItem;
    }

    public void ApplyDifference(PresetItemType obj)
    {
        if (obj.ItemClassId is not null)
            ItemClassId = $"{obj.ItemClassId}";

        if (obj.AmountSpecified)
        {
            Amount = obj.Amount;
            AmountSpecified = obj.AmountSpecified;
        }

        if (obj.WeightSpecified)
        {
            Weight = obj.Weight;
            WeightSpecified = obj.WeightSpecified;
        }

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

        if (obj.QualitySpecified)
        {
            Quality = obj.Quality;
            QualitySpecified = obj.QualitySpecified;
        }

        if (obj.ConditionSpecified)
        {
            Condition = obj.Condition;
            ConditionSpecified = obj.ConditionSpecified;
        }

        if (ConditionVariationSpecified && obj.ConditionVariationSpecified)
        {
            ConditionVariation = obj.ConditionVariation;
            ConditionVariationSpecified = obj.ConditionVariationSpecified;
        }
    }

    public static bool operator ==(PresetItemType lhs, PresetItemType rhs)
    {
        if (lhs is null && rhs is null) return true;
        if (lhs is null || rhs is null) return false;
        return lhs.Equals(rhs);
    }

    public static bool operator !=(PresetItemType lhs, PresetItemType rhs) => !(lhs == rhs);
}