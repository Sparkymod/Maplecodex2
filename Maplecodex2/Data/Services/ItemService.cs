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
        private Task<List<Item>> GetDataItems(string search, string selectedOption)
        {
            int value = !string.IsNullOrEmpty(search) && char.IsDigit(search, 0) ? int.Parse(search) : 0;

            List<Item> results = DataHelperService.Instance.ItemList;

            if (string.IsNullOrEmpty(selectedOption) && string.IsNullOrEmpty(search))
            {
                return Task.FromResult(results.ToList());
            }

            // Default duck
            if (!string.IsNullOrEmpty(selectedOption) && selectedOption == "Id")
            {
                return Task.FromResult(results.FindAll(item => item.Info.Id.CompareWith(value)));
            }
            else if (value > 0)
            {
                return Task.FromResult(results.FindAll(item => item.Info.Id.CompareWith(value)));
            }

            return Task.FromResult(results.ToList());
        }
        #endregion

        public async Task<PagedList<Item>> GetItemsAsync(bool newSearch, string search, string selectedOption, int pageNumber = 1, int pageSize = 10)
        {
            if (ResultsFromQuery is null || newSearch)
            {
                ResultsFromQuery = await GetDataItems(search, selectedOption);
            }
            int count = ResultsFromQuery.Count;
            IEnumerable<Item> agentList = ResultsFromQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedList<Item>(agentList, count, pageNumber, pageSize);
        }
    }
}
