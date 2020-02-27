using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using dotnet_ef_web_api_order.Models;

namespace dotnet_ef_web_api_orders.Controllers
{
    [ApiController]
    [Route("[order]")]
    public class OrderController : ControllerBase
    {
        private static List<Order> Orders = new List<rder>(){
            new Order{Id=1, User_id= "Ackerman Levi", Status="manifested", Driver_id="john@doe.com", Created_at="21/02/2020", Update_at="29/02/2020"},
            new Order{Id=2, User_id= "Uzumaki Indre", Status="delivered", Driver_id="john@doe.com", Created_at="22/02/2020", Update_at="29/02/2020"
        }
    };

    private readonly ILogger<OrderController> _logger;
    private HttpClient _client;

    public OrderController(ILogger<OrderController> logger, HttpClient client)
    {
        _logger = logger;
        _client = client;

    }
    [HttpGet]
    public async Task<IActionResut> Get()
    {
        var result = await _client.GetStringAync("/order");
        Console.WriteLine(result);
        return Ok(new {message = "success retrieve data", status = true, data = Orders });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new {message="success retrieve data", status= true, data = Orders.Find(dataidnya => dataidnya.Id == id)});

    }
    [HttpPost]
    public IActionResult CustomerAdd(CustomersRequest customer)
    {
        var orderAdd = new Customer() { Id= order.Id , Status = order.Status, Driver_id = order.Driver_id, Created_at = order.Created_at, Update_at = order.Update_at};
        Orders.Add(orderAdd);
        return Ok(new { data = Orders });

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        Order order = order.Find(id);
        if (order == null)
        {
            return HttpNotFound();
        }
        Order.Remove(order);
        Order.SaveChanges();
        return Ok(new {data=Orders});
    }

    [HttpPut("{id}")]
    public IActionResult PutById(int id)
    {
        Order order = order.Find(id);
        var orderPut = new Customer() { Id= order.Id , Status = order.Status, Driver_id = order.Driver_id, Created_at = order.Created_at, Update_at = order.Update_at };
        Orders.Add(orderPut);
        return Ok(new { data = Orders });
    }

}