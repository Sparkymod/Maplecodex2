using Maplecodex2.DBSync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml2CSharp;

namespace Maplecodex2.Tools
{
    public static class XmlToClass
    {
        public static void Export(string[] files)
        {
            ConsoleUtility.TotalProgressCount = files.Length;
            ConsoleUtility.ProgressCount = 1;

            string xmlPrevious = "";
            string xml = "";
            ClassInfoWriter finalClass = default;

            foreach (string file in files)
            {
                ConsoleUtility.ClassName = $"ItemTemplateParser";
                ConsoleUtility.ProgressCount++;
                ConsoleUtility.WriteProgressBar();

                xmlPrevious = xml;
                xml = File.ReadAllText(file);
                //xml.Except(xmlPrevious); // Add new stuff to the newone

                IEnumerable<Class> classInfo = new Xml2CSharpConverer().Convert(xml);
                finalClass = new (classInfo, "Maplecodex2.DBSync.Data.Types");
            }

            StreamWriter writer = new StreamWriter("../../../../ExportClasses/FinalXML.cs");
            finalClass.Write(writer);
        }
    }
}
