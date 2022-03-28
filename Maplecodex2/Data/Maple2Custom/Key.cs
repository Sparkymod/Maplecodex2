using System.Xml.Serialization;
using System.Xml;
using M2dXmlGenerator;

namespace Maplecodex2.Data.Maple2Custom
{
    public class Key : IFeatureLocale
    {
        public string Feature => _feature;
        public string Locale => _locale;

        [XmlAttribute]
        public int id;

        [XmlAttribute]
        public string name = string.Empty;

        [XmlAttribute("class")]
        public string type = string.Empty;

        [XmlAttribute("feature")]
        public string _feature = string.Empty;

        [XmlAttribute("locale")]
        public string _locale = string.Empty;

        [XmlAttribute]
        public string tooltipDescription = string.Empty;

        [XmlAttribute]
        public string guideDescription = string.Empty;


    }
}
