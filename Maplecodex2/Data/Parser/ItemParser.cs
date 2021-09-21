using Maplecodex2.Data.Models;
using Maplecodex2.Data.Helpers;
using System.Xml;
using System.Reflection;
using System.Linq;

namespace Maplecodex2.Data.Parser
{
    public static class ItemParser
    {
        /// <summary>
        /// ...
        /// </summary>
        /// <returns>List of Item.</returns>
        public static Dictionary<int, Item> Items()
        {
            Dictionary<int, Item> itemList = new();

            XmlDocument itemname = DataHelper.ReadDataFromXml(Paths.XML_ITEM);
            XmlNodeList itemNodes = itemname.SelectNodes("ms2/key");

            foreach (XmlNode node in itemNodes)
            {
                // Set Item values
                Item item = new();

                // From itemname
                item.Id = int.Parse(node.Attributes["id"]?.Value ?? "0");
                item.Type = node.Attributes["class"]?.Value ?? "NaN";
                item.Name = node.Attributes["name"]?.Value ?? "NaN";
                item.Feature = node.Attributes["feature"]?.Value ?? "NaN";
                item.Locale = node.Attributes["locale"]?.Value ?? "NaN";

                itemList[item.Id] = item;
            }

            foreach (string entry in DataHelper.GetAllFilesFrom("item"))
            {
                int id = int.Parse(Path.GetFileNameWithoutExtension(entry));

                if (!itemList.ContainsKey(id)) { continue; }

                // Read and save the XML in document.
                XmlDocument document = DataHelper.ReadDataFromXml(entry);

                // Root node for start reading.
                XmlNode property = document.SelectSingleNode("ms2/environment/property");

                // From each id.xml
                string icon = "NaN";
                if (property.Attributes["slotIcon"] != null)
                {
                    icon = property.Attributes["slotIcon"].Value != "icon0.png" ? property.Attributes["slotIcon"].Value : property.Attributes["slotIconCustom"].Value;
                }
                
                string category = "NaN";
                if(property.Attributes["category"] != null && string.IsNullOrEmpty(property.Attributes["category"].Value))
                {
                    category = property.Attributes["category"].Value;
                }
                
                itemList[id].Icon = icon;
                itemList[id].Category = category;
            }

            return itemList;
        }
    }
}
