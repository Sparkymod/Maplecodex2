using Maplecodex2.Data.Helpers;
using Maplecodex2.Database.Pagination;
using Microsoft.AspNetCore.Components;

namespace Maplecodex2.Data.Models
{
    public class DataViewModel<T> : ComponentBase
    {
        public DataHelper Helper { get; set; } = new();
        public PagedList<T> PagedResults { get; set; }
        public List<PagingLink> Links { get; set; } = new();
        public PagingLink CurrentLink { get; set; }

        [Parameter] public int PageSize { get; set; } = 10;
        [Parameter] public string SearchBy { get; set; }
        [Parameter] public string SelectedOption { get; set; }

        public virtual void FirstInitialize() { }

        public virtual async Task ShowResults() => await Task.CompletedTask;

        // Generate Data for Current Page on Pagination.
        public Task OnSelectedPage(PagingLink link)
        {
            if (PagedResults == null || link.Page == PagedResults.CurrentPage || !link.Enabled)
            {
                return Task.CompletedTask;
            }

            CurrentLink = link;
            PagedResults.CurrentPage = link.Page;

            if (Links != null && Links.Any())
            {
                Links.Clear();
            }

            Links = Helper.CreatePaginationLinks(PagedResults, 5);
            return Task.CompletedTask;
        }
    }
}
