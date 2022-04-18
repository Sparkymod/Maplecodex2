using System.Xml.Serialization;

namespace Maplecodex2.Data.Maple2Custom.Keys
{
    public class ItemOptionsConstantKey
    {
        [XmlAttribute("code")]
        public int Id;
        [XmlAttribute("grade")]
        public int Rarity;
    }

    public class ItemOptionsRandomKey
    {
        [XmlAttribute("code")]
        public int Id;
        [XmlAttribute("grade")]
        public byte Rarity;
        [XmlAttribute("multiply_factor")]
        public float MultiplyFactor;
    }

    public class ItemOptionsStaticKey
    {
        [XmlAttribute("code")]
        public int Id;
        [XmlAttribute("nddcalibrationfactor_rate_base")]
        public float DefenseCalibrationFactor;
        [XmlAttribute("hiddennddadd_value_base")]
        public int HiddenDefenseAdd;
        [XmlAttribute("wapcalibrationfactor_rate_base")]
        public float WeaponAtkCalibrationFactor;
        [XmlAttribute("hiddenwapadd_value_base")]
        public int HiddenWeaponAtkAdd;
    }
}
