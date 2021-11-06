using Maplecodex2.Data.Helpers;

namespace Maplecodex2.Tools
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XmlToClass.Export(FileHelper.GetAllFilesFrom(Paths.XML_ROOT, "item").ToArray());
        }
    }
}