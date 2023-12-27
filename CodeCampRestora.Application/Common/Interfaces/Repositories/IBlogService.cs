using CodeCampRestora.Application.DTOs;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories
{
    public interface IBlogService
    {
        Task<List<BlogDto>> GetAll();
        Task<BlogDto?> GetById(int id);
        Task Add(BlogDto blog);
        Task Update(int id, BlogDto blog);
        Task Delete(int id);
    }
}
