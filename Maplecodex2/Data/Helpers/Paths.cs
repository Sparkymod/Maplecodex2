namespace Maplecodex2.Data.Helpers
{
    public static class Paths
    {
        public static readonly string SOLUTION_DIR = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../.."));
        // XML PATHS
        public static readonly string XML_ROOT = Path.Combine(SOLUTION_DIR, "Maplecodex2.DBSync/Data/Xml");
        public static readonly string XML_ITEM = Path.Combine(XML_ROOT, "string/en/itemname.xml");
        public static readonly string XML_MAP = Path.Combine(XML_ROOT, "string/en/mapname.xml");
        public static readonly string XML_NPC = Path.Combine(XML_ROOT, "string/en/npcname.xml");
    }
}
