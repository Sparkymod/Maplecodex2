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

            foreach (string entry in DataHelper.GetAllFilesFrom("item"))
            {
                // Read and save the XML in document.
                XmlDocument document = DataHelper.ReadDataFromXml(entry);
                
                // Root node for start reading.
                XmlNodeList environmentNodes = document.SelectNodes("ms2/environment");

                Item item = new ();

                foreach (XmlNode node in environmentNodes)
                {
                    XmlNode property = node.SelectSingleNode("property");

                    // Set Icon
                    item.Icon = property.Attributes["slotIcon"].Value != "icon0.png" ? property.Attributes["slotIcon"].Value : property.Attributes["slotIconCustom"].Value;
                    
                }
                // 
                //XmlNodeList itemNodes = document.SelectNodes("ms2/key");
                //foreach (XmlNode item in itemNodes)
                //{
                //    int id = int.Parse(item.Attributes["id"]?.Value ?? "0");
                //    string type = item.Attributes["class"]?.Value ?? "NOT_DEFINED";
                //    string name = item.Attributes["name"]?.Value ?? "NOT_DEFINED";
                //    string feature = item.Attributes["feature"]?.Value ?? "NOT_DEFINED";
                //    string locale = item.Attributes["locale"]?.Value ?? "NOT_DEFINED";

                //    itemList.Add(new Item(id, type, name, feature, locale));
                //}
            }
            return itemList;
        }
    }
}
