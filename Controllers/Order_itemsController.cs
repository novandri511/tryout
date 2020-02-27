using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using dotnet_ef_web_api_Order_items.Models;

namespace dotnet_ef_web_api_Order_items.Controllers
{
    [ApiController]
    [Route("[Order_items]")]
    public class OrderitemsController : ControllerBase
    {
        private static List<Order_item> Order_items = new List<Order_item>(){
            new Order_item{Order_id = 1, Product_id = 1, Quantity = "100"},
            new Order_item{Order_id = 2, Product_id = 2, Quantity = "10"}
            
        }
    };

    private readonly ILogger<OrderitemsController> _logger;
    private HttpClient _client;

    public OrderitemsController(ILogger<OrderitemsController> logger, HttpClient client)
    {
        _logger = logger;
        _client = client;

    }
    [HttpGet]
    public async Task<IActionResut> Get()
    {
        var result = await _client.GetStringAync("/order_item");
        Console.WriteLine(result);
        return Ok(new {message = "success retrieve data", status = true, data = Order_items });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new {message="success retrieve data", status= true, data = Order_items.Find(dataidnya => dataidnya.Id == id)});

    }
    [HttpPost]
    public IActionResult ProductAdd(Order_itemsRequest order_item)
    {
        var order_itemAdd = new Order_item() { Order_id= order_item.Order_id , Product_id = order_item.Product_id, Quantity = order_item.Quantity};
        Order_items.Add(order_itemAdd);
        return Ok(new { data = Order_items });

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        Order_item order_item = order_item.Find(id);
        if (order_item == null)
        {
            return HttpNotFound();
        }
        Order_item.Remove(order_item);
        Order_item.SaveChanges();
        return Ok(new {data=Order_items});
    }

    [HttpPut("{id}")]
    public IActionResult PutById(int id)
    {
        Products product = product.Find(id);
        var order_itemPut = new Order_item() { Order_id= order_item.Order_id , Product_id = order_item.Product_id, Quantity = order_item.Quantity };
        Order_items.Add(order_itemPut);
        return Ok(new { data = Order_items });
    }

}