using M2dXmlGenerator;
using Maplecodex2.Data.Maple2Custom.Keys;
using System.Xml.Serialization;

namespace Maplecodex2.Data.Maple2Custom.Mappings
{
    [XmlRoot("ms2")]
    public class ItemOptionsConstantMapping
    {
        [XmlElement("option")]
        public List<ItemOptionsConstantKey> key;
    }

    [XmlRoot("ms2")]
    public class ItemOptionsRandomMapping
    {
        [XmlElement("option")]
        public List<ItemOptionsRandomKey> key;
    }

    [XmlRoot("ms2")]
    public class ItemOptionsStaticMapping
    {
        [XmlElement("option")]
        public List<ItemOptionsStaticKey> key;
    }
}
