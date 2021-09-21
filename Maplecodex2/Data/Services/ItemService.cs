using Maplecodex2.Data.Storage;
using Maplecodex2.Data.Models;
using Maplecodex2.Database.Managers;

namespace Maplecodex2.Data.Services
{
    public class ItemService
    {
        public Task<Item> GetItemAsync(int id)
        {
            ItemManager manager = new ItemManager(Settings.GetDbContext());

            return manager.Get(id);
            //return Task.FromResult(ItemStorage.GetItem(id));
        }
    }
}
