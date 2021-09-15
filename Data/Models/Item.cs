using System.Xml.Serialization;

namespace Maplecodex2.Data.Models
{
    [XmlType]
    public class Item
    {
        [XmlElement(Order = 1)]
        public int Id;
        [XmlElement(Order = 2)]
        public string Type;
        [XmlElement(Order = 3)]
        public string Name;
        [XmlElement(Order = 4)]
        public string Feature;
        [XmlElement(Order = 5)]
        public string Locale;

        public Item() { }

        public Item(int id, string clas, string name, string feature, string locale)
        {
            Id = id;
            Type = clas;
            Name = name;
            Feature = feature;
            Locale = locale;
        }
    }
}
