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
        private Task<List<Item>> GetDataItems(int id, string name, string type, string selectedOption)
        {
            IEnumerable<Item> results = null;


            results = from item in DataHelperService.Instance.ItemList
                                        where item.Info.Id == id || item.Info.Name == name || item.Info.Type == type
                                        select item;

            return Task.FromResult(results.ToList());
        }
        #endregion

        public async Task<PagedList<Item>> GetAgentsAsync(bool newSearch, int id, string name, string type, string selectedOption, int pageNumber = 1, int pageSize = 10)
        {
            if (ResultsFromQuery is null || newSearch)
            {
                ResultsFromQuery = await GetDataItems(id, name, type, selectedOption);
            }
            int count = ResultsFromQuery.Count;
            IEnumerable<Item> agentList = ResultsFromQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new PagedList<Item>(agentList, count, pageNumber, pageSize);
        }
    }
}
