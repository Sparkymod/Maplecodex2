using System.Xml.Serialization;
using System.Xml;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.IO;
using Maplecodex2.Data.Models;
using Maplecodex2.Data.Maple2Custom.Mappings;
using Maplecodex2.Data.Maple2Custom.Keys;
using Serilog;
using System.Diagnostics;

namespace Maplecodex2.Data.Maple2Custom
{
    public class ItemParser
    {
        private readonly M2dReader xmlReader;

        private readonly XmlSerializer nameSerializer;
        private readonly XmlSerializer itemSerializer;
        private readonly XmlSerializer descriptionSerializer;
        // ItemOptions Serializers
        private readonly XmlSerializer itemOptionConstantSerializer;
        private readonly XmlSerializer itemOptionRandomSerializer;
        private readonly XmlSerializer itemOptionStaticSerializer;

        public ItemParser(M2dReader xmlReader)
        {
            this.xmlReader = xmlReader;
            nameSerializer = new XmlSerializer(typeof(StringMapping));
            itemSerializer = new XmlSerializer(typeof(ItemDataRoot));
            descriptionSerializer = new XmlSerializer(typeof(StringMapping));

            itemOptionConstantSerializer = new XmlSerializer(typeof(ItemOptionsConstantMapping));
            itemOptionRandomSerializer = new XmlSerializer(typeof(ItemOptionsRandomMapping));
            itemOptionStaticSerializer = new XmlSerializer(typeof(ItemOptionsStaticMapping));
        }

        public List<Item> Parse()
        {
            var results = new List<Item>();
            XmlReader itemNameReader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/itemname.xml"));
            XmlReader itemDescriptionReader = xmlReader.GetXmlReader(xmlReader.GetEntry("string/en/koritemdescription.xml"));

            StringMapping itemNameMapping = nameSerializer.Deserialize(itemNameReader) as StringMapping;
            StringMapping itemDescriptionMapping = descriptionSerializer.Deserialize(itemDescriptionReader) as StringMapping;

            Dictionary<int, string> itemNames = itemNameMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.name);
            Dictionary<int, string> itemTypes = itemNameMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.type);
            Dictionary<int, string> itemToolDesc = itemDescriptionMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.tooltipDescription);
            Dictionary<int, string> itemGuideDesc = itemDescriptionMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.guideDescription);
            Dictionary<int, string> itemMainDesc = itemDescriptionMapping.key.ToDictionary((Key key) => key.id, (Key key) => key.mainDescription);
            Dictionary<int, List<int?>> iOCoption = new ();

            // Get itemoption Constant
            foreach (PackFileEntry item in xmlReader.Files.Where((PackFileEntry entry) => entry.Name.StartsWith("itemoption/option/random"))) // itemoption/constant
            {
                ItemOptionsConstantMapping iOCMapping = itemOptionConstantSerializer.Deserialize(xmlReader.GetXmlReader(item)) as ItemOptionsConstantMapping;
                foreach (var iOC in iOCMapping.key)
                {
                    if (iOCoption.ContainsKey(iOC.Id))
                    {
                        iOCoption[iOC.Id].Add(iOC.Rarity);
                        continue;
                    }

                    iOCoption.Add(iOC.Id, new List<int?>() { iOC.Rarity });
                }
            }

            // Get itemoption Random
            //foreach (PackFileEntry item in xmlReader.Files.Where((PackFileEntry entry) => entry.Name.StartsWith("itemoption/option/random")))
            //{
            //    ItemOptionsRandomMapping iORMapping = itemOptionRandomSerializer.Deserialize(xmlReader.GetXmlReader(item)) as ItemOptionsRandomMapping;
            //    foreach (var iOR in iORMapping.key)
            //    {
            //        // TODO:
            //    }
            //}

            // Get itemoption Static
            //foreach (PackFileEntry item in xmlReader.Files.Where((PackFileEntry entry) => entry.Name.StartsWith("itemoption/option/static")))
            //{
            //    ItemOptionsStaticMapping iOSMapping = itemOptionStaticSerializer.Deserialize(xmlReader.GetXmlReader(item)) as ItemOptionsStaticMapping;
            //    foreach (var iOS in iOSMapping.key)
            //    {

            //    }
            //}

            foreach (PackFileEntry item in xmlReader.Files.Where((PackFileEntry entry) => entry.Name.StartsWith("item/")))
            {
                ItemData data = (itemSerializer.Deserialize(xmlReader.GetXmlReader(item)) as ItemDataRoot).environment;
                if (data != null)
                {
                    int id = int.Parse(Path.GetFileNameWithoutExtension(item.Name));
                    ItemInfo info = new();
                    try
                    {
                        info.Id = id;
                        info.Name = itemNames.GetValueOrDefault(id);
                        info.MainDescription = itemMainDesc.GetValueOrDefault(id);
                        info.GuideDescription = itemGuideDesc.GetValueOrDefault(id);
                        info.ToolDescription = itemToolDesc.GetValueOrDefault(id);
                        info.Type = itemTypes.GetValueOrDefault(id);
                        info.Rarities = iOCoption.GetValueOrDefault(id);
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Error found with ID: {0}, Message: {1}", id, ex.Message);
                        throw;
                    }

                    results.Add(new Item(info, data));
                }
            }

            return results;
        }
    }
}
