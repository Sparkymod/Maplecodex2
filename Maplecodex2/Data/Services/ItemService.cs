using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Models;
using Maplecodex2.Database.Core;

namespace Maplecodex2.Data.Services
{
    public class ItemService
    {
        public ICollection<Item> Items { get; set; }
        public List<Item> ResultsFromQuery { get; set; }

        public ItemService()
        {
            using DatabaseRequest<Item> Context = new();
            Items = Context.GetAll().Result;
        }

        private Task<List<Item>> GetDataItems(string searchValue)
        {
            int value = !string.IsNullOrEmpty(searchValue) && char.IsDigit(searchValue, 0) ? int.Parse(searchValue) : 0;
            ResultsFromQuery = Items.ToList();

            if (value > 0)
            {
                return Task.FromResult(ResultsFromQuery.FindAll(item => item.Id.CompareWith(value)));
            }
            else if(!string.IsNullOrEmpty(searchValue) && char.IsLetter(searchValue, 0))
            {
                return Task.FromResult(ResultsFromQuery.FindAll(item => item.Id.CompareWith(value)));
            }
            else
            {
                return Task.FromResult(ResultsFromQuery);
            }
        }

        public async Task<PagedList<Item>> GetItemAsync(bool newSearch, string search, int pageNumber, int pageSize)
        {
            if (ResultsFromQuery == null || newSearch)
            {
                ResultsFromQuery = await GetDataItems(search);
            }
            int count = ResultsFromQuery.Count;
            IEnumerable<Item>? itemsForPage = ResultsFromQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedList<Item>(itemsForPage, count, pageNumber, pageSize);
        }

        public Task<PagedList<Item>> GetItemsDefault(int pageNumber, int pageSize)
        {
            int count = Items.Count;
            IEnumerable<Item>? itemsForPage = Items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return Task.FromResult(new PagedList<Item>(itemsForPage, count, pageNumber, pageSize));
        }
    }
}
