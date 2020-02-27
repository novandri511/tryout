using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using dotnet_ef_web_api_product.Models;

namespace dotnet_ef_web_api_product.Controllers
{
    [ApiController]
    [Route("[product]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> Products = new List<Product>(){
            new Product{Id=1, Names="Pembersih Luka Kenangan Masa lalu", Price="Mahal", Created_at="21/02/2020" , Updated_at="22/02/2020" },
            new Product{Id=2, Names="Penumbuh Ingatan untuk Amnesia", Price="Mahal banget", Created_at="21/02/2020" , Updated_at="22/02/2020" }
            
        }
    };

    private readonly ILogger<ProductController> _logger;
    private HttpClient _client;

    public ProductController(ILogger<ProductController> logger, HttpClient client)
    {
        _logger = logger;
        _client = client;

    }
    [HttpGet]
    public async Task<IActionResut> Get()
    {
        var result = await _client.GetStringAync("/product");
        Console.WriteLine(result);
        return Ok(new {message = "success retrieve data", status = true, data = Products });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new {message="success retrieve data", status= true, data = Products.Find(dataidnya => dataidnya.Id == id)});

    }
    [HttpPost]
    public IActionResult ProductAdd(ProductsRequest product)
    {
        var productAdd = new Product() { Id= product.Id , Names = product.Names, Price = product.Price, Created_at = product.Created_at , Update_at = product.Update_at };
        Products.Add(productAdd);
        return Ok(new { data = Products });

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        Product product = product.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        Product.Remove(product);
        Product.SaveChanges();
        return Ok(new {data=Products});
    }

    [HttpPut("{id}")]
    public IActionResult PutById(int id)
    {
        Products product = product.Find(id);
        var productPut = new Product() { Id= product.Id , Names = product.Names, Price = product.Price, Created_at = product.Created_at , Update_at = product.Update_at };
        Products.Add(productPut);
        return Ok(new { data = Products });
    }

}