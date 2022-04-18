using Maplecodex2.Data.Extensions;
using Maplecodex2.Data.Models;
using Maplecodex2.Database.Pagination;

namespace Maplecodex2.Data.Services
{
    public class ItemService
    {
        public List<Item> ResultsFromQuery { get; set; }
        public DateTime LastAgentTime;

        public ItemService() { }

        #region GET REQUESTS
        private Task<List<Item>> GetDataItems(string search)
        {
            int value = !string.IsNullOrEmpty(search) && char.IsDigit(search, 0) ? int.Parse(search) : 0;

            IEnumerable<Item> results = DataHelperService.Instance.ItemList;

            if (string.IsNullOrEmpty(search))
            {
                ResultsFromQuery = results.ToList();
                return Task.FromResult(ResultsFromQuery);
            }

            results = from item in results
                      where item.Info.Name.CompareWith(search)
                      || item.Info.Type.CompareWith(search)
                      || item.Info.Id.CompareWith(value)
                      select item;
            ResultsFromQuery = results.ToList();
            return Task.FromResult(ResultsFromQuery);
        }
        #endregion

        public async Task<PagedList<Item>> GetItemsAsync(bool newSearch, string search, int pageNumber = 1, int pageSize = 10)
        {
            if (ResultsFromQuery is null || newSearch)
            {
                ResultsFromQuery = await GetDataItems(search);
            }
            int count = ResultsFromQuery.Count;
            IEnumerable<Item> agentList = ResultsFromQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedList<Item>(agentList, count, pageNumber, pageSize);
        }
    }
}
