using System.Reflection;
using System.Linq;

namespace Maplecodex2.Data.Helpers
{
    public static class Paths
    {
        public static readonly string SOLUTION_DIR = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../.."));
        // ICON PATHS
        public static readonly string ICON_ITEM = Path.Combine(SOLUTION_DIR, "Maplecodex2/Data/Icons/Item");
        // XML PATHS
        public static readonly string XML_ROOT = Path.Combine(SOLUTION_DIR, "Maplecodex2/Data/Xml");
        public static readonly string XML_ITEM = Path.Combine(XML_ROOT, "itemname.xml");
        public static readonly string XML_MAP = Path.Combine(XML_ROOT, "mapname.xml");
        public static readonly string XML_NPC = Path.Combine(XML_ROOT, "npcname.xml");
    }
}
