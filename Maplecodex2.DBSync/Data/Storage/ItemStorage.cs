using Maplecodex2.Data.Models;
using Maplecodex2.Data.Parser;

namespace Maplecodex2.DBSync.Data.Storage
{
    public static class ItemStorage
    {
        private static Dictionary<int, Item> Items = new();

        public static void Init() => Items = ItemParser.Parse();

        public static Item GetItem(int id) => Items.GetValueOrDefault(id);

        public static IEnumerable<Item> GetAll() => Items.Values;
    }
}
