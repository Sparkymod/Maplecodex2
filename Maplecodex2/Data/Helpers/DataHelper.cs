using Maplecodex2.Database.Pagination;

namespace Maplecodex2.Data.Helpers
{
    public class DataHelper
    {
        public List<PagingLink> CreatePaginationLinks<T>(PagedList<T> pagedList, int paginationSize)
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
    }
}
