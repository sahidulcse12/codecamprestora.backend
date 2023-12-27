using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Infrastructure.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;
        private readonly AppDbContext _context;

        public BlogService(IRepository<Blog> blogRepository, AppDbContext context)
        {
            _blogRepository = blogRepository;
            _context = context;
        }

        public async Task<List<BlogDto>> GetAll()
        {
            var listOfBlogs = await _blogRepository.GetAllAsync();

            var blogDtos = new List<BlogDto>();
            foreach (var item in listOfBlogs)
            {
                var blogDto = new BlogDto
                {
                    Id = item.Id,
                    Author = item.Author,
                    Description = item.Description,
                    Name = item.Name
                };

                blogDtos.Add(blogDto);
            }

            return blogDtos;
        }

        public async Task<BlogDto?> GetById(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
            if(blog is null)
            {
                return null;
            }

            var blogDto = new BlogDto
            {
                Id = blog.Id,
                Author = blog.Author,
                Description = blog.Description,
                Name = blog.Name
            };

            return blogDto;
        }

        public async Task Add(BlogDto blog)
        {
            var newBlog = new Blog
            {
                Name = blog.Name,
                Description = blog.Description,
                Author = blog.Author,
            };
            await _blogRepository.AddAsync(newBlog);
        }

        public async Task Delete(int id)
        {
            await _blogRepository.DeleteAsync(id);
        }

        public async Task Update(int id, BlogDto blog)
        {
            var singleBlog = await _blogRepository.GetByIdAsync(id);
            if (singleBlog is null)
            {
                return;
            }
            singleBlog.Name = blog.Name;
            singleBlog.Description = blog.Description;
            singleBlog.Author = blog.Author;

            await _blogRepository.UpdateAsync(id, singleBlog);
        }
    }
}
