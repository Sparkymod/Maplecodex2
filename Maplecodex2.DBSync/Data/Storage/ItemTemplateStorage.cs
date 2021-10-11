using Maplecodex2.Data.Models;
using Maplecodex2.Data.Parser;
using Maplecodex2.DBSync.Data.Types;
using Maplecodex2.DBSync.Parser;

namespace Maplecodex2.DBSync.Data.Storage
{
    public static class ItemTemplateStorage
    {
        public static Dictionary<int, List<Node>> ItemXml { get; set; }

        public static void Init() => ItemXml = ItemTemplateParser.Parse();
    }
}
