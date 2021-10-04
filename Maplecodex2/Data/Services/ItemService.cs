using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;
using Maplecodex2.Data.Extensions;

namespace Maplecodex2.Data.Services
{
    public class ItemService : DatabaseRequest<Item>
    {
        private static Task<List<Item>>? Items;

        public async Task<PagedList<Item>> GetItemsPerPage(int pageNumber, int pageSize)
        {
            Items = GetAll();
            List<Item>? products = await Items;
            int count = products.Count;
            List<Item>? items = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<Item>(items, count, pageNumber, pageSize);
        }

        public async Task<PagedList<Item>> GetItemPerPageById(int id, int pageNumber, int pageSize)
        {
            List<Item>? products = await Items;
            List<Item>? matchItems = products.FindAll(item => item.Id.CompareWith(id));
            List<Item>? items = matchItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            int count = matchItems.Count;

            return new PagedList<Item>(items, count, pageNumber, pageSize);
        }

        public async Task<PagedList<Item>> GetItemPerPageByName(string name, int pageNumber, int pageSize)
        {
            List<Item>? products = await Items;
            List<Item>? matchItems = products.FindAll(item => item.Name.CompareWith(name));
            List<Item>? items = matchItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            int count = matchItems.Count;

            return new PagedList<Item>(items, count, pageNumber, pageSize);
        }
    }
}
