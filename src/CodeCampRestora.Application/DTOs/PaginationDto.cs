using CodeCampRestora.Application.Common.Helpers.Pagination;

namespace CodeCampRestora.Application.DTOs
{
    public class PaginationDto<T> where T : class
    {
        public PagedList<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public PaginationDto(PagedList<T> data, int totalCount, int totalPages)
        {
            Data = data;
            TotalCount = totalCount;
            TotalPages = totalPages;
        }
    }
}