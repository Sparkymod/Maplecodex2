using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;

namespace Maplecodex2.Data.Services
{
    public class ItemService : DatabaseRequest<Item>
    {
        public async Task<Item> GetItemAsync(int id) => await Get(id);

        public async Task<PagedList<Item>> GetItemsPerPage(int pageNumber, int pageSize)
        {
            List<Item>? products = await GetAll();
            int count = products.Count;
            List<Item>? items = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<Item>(items, count, pageNumber, pageSize);
        }

        public async Task<PagedList<Item>> GetItemPerPageById(int id, int pageNumber, int pageSize)
        {
            List<Item>? products = await GetAll();
            List<Item>? matchItems = products.FindAll(item => item.Id.ToString().Contains(id.ToString()));
            List<Item>? items = matchItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            int count = matchItems.Count;

            return new PagedList<Item>(items, count, pageNumber, pageSize);
        }

        public async Task<PagedList<Item>> GetItemPerPageByName(string name, int pageNumber, int pageSize)
        {
            List<Item>? products = await GetAll();
            List<Item>? matchItems = products.FindAll(item => item.Name.Contains(name));
            List<Item>? items = matchItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            int count = matchItems.Count;

            return new PagedList<Item>(items, count, pageNumber, pageSize);
        }
    }
}
