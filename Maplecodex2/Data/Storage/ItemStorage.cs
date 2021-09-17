using Maplecodex2.Data.Helpers;
using Maplecodex2.Data.Models;
using Maplecodex2.Data.Parser;
using System.Linq;

namespace Maplecodex2.Data.Storage
{
    public static class ItemStorage
    {
        private static readonly Dictionary<int, Item> Items = new();

        public static void Init() => ItemParser.Items().ForEach(item => Items[item.Id] = item);

        public static Item GetItem(int id) => Items.GetValueOrDefault(id);
    }
}
