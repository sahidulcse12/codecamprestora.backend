using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCampRestora.Api.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Blog>>> GetAll()
        {
            var item = await _blogService.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetById(int id)
        {
            var result = await _blogService.GetById(id);
            if (result is null)
                return NotFound("Student not found.");

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task AddBlog(BlogDto blog)
        {
            await _blogService.Add(blog);
        }

        [HttpPut("{id}")]
        public async Task Update(int id, BlogDto blog)
        {
            var singleBlog = await _blogService.GetById(id);
            if (singleBlog is null)
            {
                return;
            }
            await _blogService.Update(id, blog);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _blogService.Delete(id);
        }

    }
}
