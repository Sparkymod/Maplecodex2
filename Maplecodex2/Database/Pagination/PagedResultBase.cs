using Serilog;

namespace RDK.Database.Pagination
{
    public class PagedResult<T>
    {
        public IList<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public bool IsFirst => CurrentPage == 1;
        public bool IsLast => CurrentPage == TotalPages;

        public PagedResult()
        {
            Results = new List<T>();
        }

        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public static class PagedResultExtension
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }

    public class PaginationLinks
    {
        public List<PagingLink> CreatePaginationLinks<T>(PagedResult<T> pagedList, int paginationSize)
        {
            try
            {
                List<PagingLink> links = new();

                PagingLink newPage = new(pagedList.CurrentPage - 1, pagedList.HasPrevious, "Anterior", "Página anterior");
                links.Add(newPage);

                newPage = new(1, pagedList.HasPrevious, "<<", "Primera página");
                links.Add(newPage);

                for (int pageNumber = 1; pageNumber <= pagedList.TotalPages; pageNumber++)
                {
                    newPage = new(pageNumber, true, pageNumber.ToString(), $"Página {pageNumber}");

                    if (pageNumber == pagedList.CurrentPage)
                    {
                        newPage.Active = pagedList.CurrentPage == pageNumber;
                    }
                    if (pageNumber >= pagedList.CurrentPage && pageNumber <= pagedList.CurrentPage + paginationSize)
                    {
                        links.Add(newPage);
                    }
                    else if (pageNumber >= pagedList.CurrentPage - paginationSize && pageNumber <= pagedList.CurrentPage && pageNumber + paginationSize >= pagedList.TotalPages)
                    {
                        links.Add(newPage);
                    }
                }

                // Show the last page available
                newPage = new(pagedList.TotalPages, pagedList.HasNext, ">>", "Última página");
                links.Add(newPage);

                newPage = new(pagedList.CurrentPage + 1, pagedList.HasNext, "Siguiente", "Página siguiente");
                links.Add(newPage);
                return links;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                return new();
            }
        }
    }

    public class PagingLink
    {
        public string Text { get; set; } = "";
        public int Page { get; set; } = 1;
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public bool Hidden { get; set; }
        public string Info { get; set; } = "";

        public PagingLink(int page, bool enabled, string text, string info)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
            Info = info;
        }

        public PagingLink()
        {

        }
    }
}
