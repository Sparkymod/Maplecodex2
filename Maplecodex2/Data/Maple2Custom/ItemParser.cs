using System.Xml.Serialization;
using System.Xml;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.IO;
using Maplecodex2.Data.Maple2Custom;

namespace Maplecodex2.Data.Models
{
    public class ItemParser
    {
        private readonly M2dReader xmlReader;

        private readonly XmlSerializer nameSerializer;

        private readonly XmlSerializer itemSerializer;

        private readonly XmlSerializer descriptionSerialize;

        public ItemParser(M2dReader xmlReader)
        {
            this.xmlReader = xmlReader;
            nameSerializer = new XmlSerializer(typeof(StringMapping));
            itemSerializer = new XmlSerializer(typeof(ItemDataRoot));
            descriptionSerialize = new XmlSerializer(typeof(StringMapping));
        }

        public IEnumerable<Item> Parse()
        {
            XmlReader itemNameReader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/itemname.xml"));
            XmlReader itemDescriptionReader = xmlReader.GetXmlReader(xmlReader.GetEntry("string/en/koritemdescription.xml"));

            StringMapping itemNameMapping = nameSerializer.Deserialize(itemNameReader) as StringMapping;
            StringMapping itemDescriptionMapping = descriptionSerialize.Deserialize(itemDescriptionReader) as StringMapping;

            Dictionary<int, string> itemNames = itemNameMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.name);
            Dictionary<int, string> itemTypes = itemNameMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.type);
            Dictionary<int, string> itemDesc = itemDescriptionMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.tooltipDescription);

            foreach (PackFileEntry item in xmlReader.Files.Where((PackFileEntry entry) => entry.Name.StartsWith("item/")))
            {
                ItemData environment = (itemSerializer.Deserialize(xmlReader.GetXmlReader(item)) as ItemDataRoot).environment;
                if (environment != null)
                {
                    int id = int.Parse(Path.GetFileNameWithoutExtension(item.Name));
                    ItemInfo info = new ItemInfo()
                    {
                        Id = id,
                        Name = itemNames.GetValueOrDefault(id),
                        Description = itemDesc.GetValueOrDefault(id),
                        Type = itemTypes.GetValueOrDefault(id),
                    };
                    yield return new Item(info, environment);
                }
            }
        }
    }
}
