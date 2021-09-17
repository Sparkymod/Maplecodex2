using Maplecodex2.Data.Storage;
using Maplecodex2.Data.Models;

namespace Maplecodex2.Data.Services
{
    public class ItemService
    {
        public Task<Item> GetItemAsync(int id) => Task.FromResult(ItemStorage.GetItem(id));
    }
}
