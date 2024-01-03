namespace CodeCampRestora.Application.Common.Helpers.Pagination
{
    public class PagedList<T> : List<T>{

        public PagedList(IEnumerable<T> currentPage, int count, int pageNumber, int pageSize){
            CurrentPage = pageNumber;
            TotalPages = (int) Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(currentPage);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> data, int pageNumber, int pageSize){
            var count = data.Count();
            var items = data.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}