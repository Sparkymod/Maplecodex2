using Maplecodex2.Data.Storage;
using Maplecodex2.Data.Models;
using Maplecodex2.Database.Managers;
using Maplecodex2.Database.Core;

namespace Maplecodex2.Data.Services
{
    public class ItemService : DatabaseRequest<Item>
    {
        public Task<Item> GetItemAsync(int id) => Get(id);
    }
}
