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
        /// Parse Items from itemname.xml
        /// </summary>
        /// <returns>List of item.</returns>
        public static List<Item> Items(string filename)
        {
            List<Item> itemList = new();
            XmlDocument document = DataHelper.ReadDataFromXml(filename);

            XmlNodeList itemNodes = document.SelectNodes("ms2/key");
            foreach (XmlNode item in itemNodes)
            {
                int id = int.Parse(item.Attributes["id"]?.Value ?? "0");
                string type = item.Attributes["class"]?.Value ?? "NOT_DEFINED";
                string name = item.Attributes["name"]?.Value ?? "NOT_DEFINED";
                string feature = item.Attributes["feature"]?.Value ?? "NOT_DEFINED";
                string locale = item.Attributes["locale"]?.Value ?? "NOT_DEFINED";

                itemList.Add(new Item(id, type, name, feature, locale));
            }

            return itemList;
        }
    }
}
