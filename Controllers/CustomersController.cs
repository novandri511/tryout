using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using dotnet_ef_web_api_customers.Models;

namespace dotnet_ef_web_api_customers.Controllers
{
    [ApiController]
    [Route("[customer]")]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> Customers = new List<Customer>(){
            new Customer{Id=1, Full_name="Johny", Username="doe", Email="john@doe.com", Phone_number="0812345689"},
            new Customer{Id=2, Full_name="Less", Username="kerk", Email="less@kerk.com", Phone_number="+628190076770"}
        }
    };

    private readonly ILogger<CustomerController> _logger;
    private HttpClient _client;

    public CustomerController(ILogger<CustomerController> logger, HttpClient client)
    {
        _logger = logger;
        _client = client;

    }
    [HttpGet]
    public async Task<IActionResut> Get()
    {
        var result = await _client.GetStringAync("/customer");
        Console.WriteLine(result);
        return Ok(new {message = "success retrieve data", status = true, data = Customers });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new {message="success retrieve data", status= true, data = Customers.Find(dataidnya => dataidnya.Id == id)});

    }
    [HttpPost]
    public IActionResult CustomerAdd(CustomersRequest customer)
    {
        var customerAdd = new Customer() { Id= customer.Id , Full_name = customer.Full_name, Username = customer.Username, Email = customer.Email, Phone_number = customer.Phone_number, Created_at = customer.Created_at , Update_at = customer.Created_at };
        Customers.Add(customerAdd);
        return Ok(new { data = Customers });

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        Customer customer = customer.Find(id);
        if (customer == null)
        {
            return HttpNotFound();
        }
        Customer.Remove(customer);
        Customer.SaveChanges();
        return Ok(new {data=Customers});
    }

    [HttpPut("{id}")]
    public IActionResult PutById(int id)
    {
        Customer customer = customer.Find(id);
        var customerPut = new Customer() { Id= customer.Id , Full_name = customer.Full_name, Username = customer.Username, Email = customer.Email, Phone_number = customer.Phone_number, Created_at = customer.Created_at , Update_at = customer.Created_at };
        Customers.Add(customerPut);
        return Ok(new { data = Customers });
    }

}