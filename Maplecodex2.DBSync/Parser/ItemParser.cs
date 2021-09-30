using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Models;
using Maplecodex2.DBSync;
using Serilog;
using System.Xml;

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
            Log.Logger.Information($"{itemNodes.Count} Items successfully loaded!".Green());
            Log.Logger.Information($"Adding extra data to items...\n".Yellow());
            List<string> itemPreset = new();

            List<string> files = DataHelper.GetAllFilesFrom(Paths.XML_ROOT, "item");
            foreach (string file in files)
            {
                ConsoleUtility.WriteProgressBar(count++, files.Count);

                int id = int.Parse(Path.GetFileNameWithoutExtension(file));
                // Read and save the XML in document.
                XmlDocument? document = DataHelper.ReadDataFromXml(file);
                if (document == null) 
                {
                    continue; 
                }

                // Root node for start reading.
                XmlNode? property = document.SelectSingleNode("ms2/environment/property");
                XmlNode? slotNode = document.SelectSingleNode("ms2/environment/slots");
                if (property == null) 
                { 
                    continue; 
                }

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

                string slot = slotNode.SelectSingleNode("slot").Attributes["name"].Value;

                string name = "";
                if (!itemList.ContainsKey(id))
                {
                    XmlNode? decal = slotNode.SelectSingleNode("slot/decal");
                    XmlNode? asset = slotNode.SelectSingleNode("slot/asset");
                    if (decal != null && decal.Attributes.Count > 0)
                    {
                        name = decal.Attributes["texture"].Value;
                    }
                    if (asset != null)
                    {
                        name = asset.Attributes["name"].Value;
                    }

                    slot = slotNode.SelectSingleNode("slot").Attributes["name"].Value;
                    Item item = new (id, "", name, "", "", icon, slot);
                    itemList.Add(id, item);

                    continue;
                }

                itemList[id].Icon = icon;
                itemList[id].Slot = slot;
            }

            return itemList;
        }
    }
}
