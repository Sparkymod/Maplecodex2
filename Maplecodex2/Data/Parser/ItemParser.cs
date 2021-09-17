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
        public static List<Item> Items()
        {
            List<Item> itemList = new();

            XmlDocument itemname = DataHelper.ReadDataFromXml(Paths.XML_ITEM);
            XmlNodeList itemNodes = itemname.SelectNodes("ms2/key");

            foreach (XmlNode node in itemNodes)
            {
                // Set Item values
                Item item = new();

                // From itemname
                item.Id = int.Parse(node.Attributes["id"]?.Value ?? "0");
                item.Type = node.Attributes["class"]?.Value ?? "NOT_DEFINED";
                item.Name = node.Attributes["name"]?.Value ?? "NOT_DEFINED";
                item.Feature = node.Attributes["feature"]?.Value ?? "NOT_DEFINED";
                item.Locale = node.Attributes["locale"]?.Value ?? "NOT_DEFINED";

                itemList.Add(item);
            }
            
            foreach (string entry in DataHelper.GetAllFilesFrom("item"))
            {
                if (itemList.Find(item => item.Id == int.Parse(Path.GetFileNameWithoutExtension(entry))) == null) { continue; }

                // Read and save the XML in document.
                XmlDocument document = DataHelper.ReadDataFromXml(entry);

                // Root node for start reading.
                XmlNode property = document.SelectSingleNode("ms2/environment/property");

                // From each id.xml
                string icon = property.Attributes["slotIcon"].Value != "icon0.png" ? property.Attributes["slotIcon"].Value : property.Attributes["slotIconCustom"].Value;
                string category = property.Attributes["category"].Value;

                itemList.Find(item => item.Id == int.Parse(Path.GetFileNameWithoutExtension(entry))).Icon = icon;
                itemList.Find(item => item.Id == int.Parse(Path.GetFileNameWithoutExtension(entry))).Category = category;
            }

            return itemList;
        }
    }
}
