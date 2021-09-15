using System.Xml;
using System.Xml.Serialization;

namespace Maplecodex2.Data.Helpers
{
    public static class DataHelper
    {
        public static void InitializeData()
        {

        }

        public static XmlDocument ReadDataFromXml(string filename)
        {
            FileStream stream = File.OpenRead(filename);
            XmlDocument document = new();
            document.Load(stream);

            return document;
        }
    }
}
