using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;

namespace Maplecodex2.Database.Managers
{
    public class ItemManager : DatabaseRequest<Item, DatabaseContext>
    {
        public ItemManager(DatabaseContext context) : base(context) { }

        public new async Task Add(Item item) => await base.Add(item);

        public new async Task Update(Item item) => await base.Update(item);
    }
}
