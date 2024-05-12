namespace JobSearch.WEB.Models
{
    public class PagedListModel<T> : List<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public PagedListModel(IEnumerable<T> items, int pageNumber, int pageSize, int totalItems)
        {
            this.ItemsPerPage = items.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalItems = totalItems;
            this.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            this.AddRange(items);
        }
    }
}
