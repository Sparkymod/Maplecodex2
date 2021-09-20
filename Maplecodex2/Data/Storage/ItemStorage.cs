using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Models;
using Maplecodex2.Data.Parser;
using System.Linq;

namespace Maplecodex2.Data.Storage
{
    public static class ItemStorage
    {
        private static Dictionary<int, Item> Items = new();

        public static void Init() => Items = ItemParser.Items();

        public static Item GetItem(int id) => Items.GetValueOrDefault(id);

        public static IEnumerable<Item> GetAll() => Items.Values;
    }
}
