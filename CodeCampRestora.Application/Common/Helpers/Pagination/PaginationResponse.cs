namespace CodeCampRestora.Application.Common.Helpers.Pagination;

public class PagedList<T> : List<T>
{
    public PagedList(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        PageSize = pageSize;
        TotalCount = totalCount;
        AddRange(items);
    }

    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public static PagedList<T> ToPagedList(IQueryable<T> data, int pageNumber, int pageSize)
    {
        var totalCount = data.Count();
        var items = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(items, totalCount, pageNumber, pageSize);
    }
}
