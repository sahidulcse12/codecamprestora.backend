namespace CodeCampRestora.Application.Common.Helpers.Pagination
{   
    public class PaginationResponse
    {
        public PaginationResponse(int currentPage, int itemsPerPage, int totalItems, int totalPages){
        CurrentPage = currentPage;
        ItemsPerPage = itemsPerPage;
        TotalItems = totalItems;
        TotalPages = totalPages;
        }
        
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}