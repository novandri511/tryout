using Microsoft.EntityFrameworkCore;

namespace dotnet-ef_web_api
{
    public class BlogContext : DbContext{

        public BlogContext(DbContextOptions<BlogContext> options): base(options){}
        public DbSet<Post>Post {get; set;}
    }
}