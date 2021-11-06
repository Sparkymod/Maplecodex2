using Maplecodex2.Data.Helpers;
using Maplecodex2.DBSync.Data.Types;
using System.Xml;

namespace Maplecodex2.DBSync.Parser
{
    public static class ItemTemplateParser
    {
        public static Dictionary<int, List<Node>> Parse()
        {
            Dictionary<int, List<Node>> itemXml = new();
            List<string> files = FileHelper.GetAllFilesFrom(Paths.XML_ROOT, "item");

            ConsoleUtility.TotalProgressCount = files.Count;
            ConsoleUtility.ProgressCount = 1;

            foreach (string file in files)
            {
                ConsoleUtility.ClassName = $"ItemTemplateParser";
                ConsoleUtility.ProgressCount++;
                ConsoleUtility.WriteProgressBar();

                int id = int.Parse(Path.GetFileNameWithoutExtension(file));

                XmlDocument? document = FileHelper.ReadDataFromXml(file);
                XmlNode ms2 = document.SelectSingleNode("ms2");

                if (ms2 == null) { continue; }

                itemXml.Add(id, XmlHelper.GetNodesFromChildNodes(ms2.ChildNodes));
            }

            return itemXml;
        }
    }
}