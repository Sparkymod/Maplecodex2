using Maplecodex2.Data.Models;
using Maplecodex2.Data.Helpers;
using System.Xml;
using Maplecodex2.DBSync;
using Serilog;

namespace Maplecodex2.Data.Parser
{
    public static class ItemParser
    {
        /// <summary>
        /// Parse Items using itemname.xml and adding additional data from Xml/items/*.*
        /// </summary>
        /// <returns>List of Item.</returns>
        public static Dictionary<int, Item> Parse()
        {
            Log.Logger.Information($"Loading...");
            Dictionary<int, Item> itemList = new();

            XmlDocument itemname = DataHelper.ReadDataFromXml(Paths.XML_ITEM);
            XmlNodeList? itemNodes = itemname.SelectNodes("ms2/key");

            int count = 1;
            int itemNodesCount = itemNodes.Count;

            foreach (XmlNode? node in itemNodes)
            {
                ConsoleUtility.WriteProgressBar(count++, itemNodesCount);

                // Set Item values
                Item item = new();

                // From itemname
                item.Id = int.Parse(node.Attributes?["id"]?.Value ?? "0");
                item.Type = node.Attributes["class"]?.Value ?? "";
                item.Name = node.Attributes["name"]?.Value ?? "";
                item.Feature = node.Attributes["feature"]?.Value ?? "";
                item.Locale = node.Attributes["locale"]?.Value ?? "";

                itemList[item.Id] = item;
            }

            count = 1;
            Log.Logger.Information($"{itemNodes.Count} Items successfully loaded!");
            Log.Logger.Information($"Adding extra data to items...");

            List<string> files = DataHelper.GetAllFilesFrom(Paths.XML_ROOT, "item");
            foreach (string file in files)
            {
                ConsoleUtility.WriteProgressBar(count++, files.Count);

                int id = int.Parse(Path.GetFileNameWithoutExtension(file));
                if (!itemList.ContainsKey(id)) 
                {
                    Console.WriteLine($"ID: {id} Not included in the itemname.xml");
                    continue; 
                }

                // Read and save the XML in document.
                XmlDocument? document = DataHelper.ReadDataFromXml(file);
                if (document == null) { continue; }

                // Root node for start reading.
                XmlNode? property = document.SelectSingleNode("ms2/environment/property");
                if (property == null) {  continue; }

                // Add aditional data to the item.
                string icon = "";
                if (property.Attributes["slotIcon"] != null)
                {
                    icon = property.Attributes["slotIcon"].Value != "icon0.png" ? property.Attributes["slotIcon"].Value : property.Attributes["slotIconCustom"].Value;
                    if (icon.StartsWith("./"))
                    {
                        icon = icon[2..];
                    }
                }
                
                string category = "";
                if (property.Attributes["category"] != null && string.IsNullOrEmpty(property.Attributes["category"].Value))
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
