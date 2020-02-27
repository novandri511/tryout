using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_ef_web_api.Controllers
{
    [ApiController]
    [route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly Illoger<BlogController> _logger;
        private readonly BlogContext _context;

        public BlogController(ILogger<BlogController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;

        }
        [HttpGet]
        public IActionResult GetPost()
        {
            var blog = new Post{
                Title = "Hello",
                Body = "World"
            };
            _context.Posts.Add(blog);
            _context.SaveChanges();

            return Ok(blog);
        }
    }
}