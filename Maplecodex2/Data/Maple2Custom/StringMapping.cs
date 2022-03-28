using System.Xml.Serialization;
using System.Xml;
using M2dXmlGenerator;

namespace Maplecodex2.Data.Maple2Custom
{
    [XmlRoot("ms2")]
    public class StringMapping
    {
        [M2dFeatureLocale(Selector = "id")]
        private IList<Key> _key;

        private List<Key> _key_;

        public IList<Key> key => _key_.FeatureLocale((Key select) => select.id).ToList();

        [XmlElement("key")]
        public List<Key> __key
        {
            get
            {
                return _key_;
            }
            set
            {
                _key_ = value;
            }
        }
    }
}
