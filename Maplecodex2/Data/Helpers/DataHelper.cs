using System.Xml;
using System.Xml.Serialization;

namespace Maplecodex2.Data.Helpers
{
    public static class DataHelper
    {
        public static void InitializeData()
        {

        }

        /// <summary>
        /// Read an xml file.
        /// </summary>
        /// <param name="filename">File path.</param>
        /// <returns>XmlDocument with the data from the xml.</returns>
        public static XmlDocument ReadDataFromXml(string filename)
        {
            FileStream stream = File.OpenRead(filename);
            XmlDocument document = new();
            document.Load(stream);

            return document;
        }

        /// <summary>
        /// Read all files in a directory and subdirectory.
        /// </summary>
        /// <param name="directory">Directory path.</param>
        /// <returns>Dictionary of folders with their files.</returns>
        public static List<string> GetAllFilesFrom(string directory)
        {
            string delimiter = $"{directory}/*.*";
            List<string> allFiles = new();

            foreach (string file in Directory.GetFiles(Paths.XML_ROOT, delimiter, SearchOption.AllDirectories))
            {
                allFiles.Add(file);
            }

            return allFiles;
        }
    }
}
