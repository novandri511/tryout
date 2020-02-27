using System.Net.Http;
using System;
using Systm.Collection.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using dotnet_ef_web_api_drivers.Models;

namespace dotnet_ef_web_api_customers.Controllers
{

    [ApiController]
    [Route("[drivers]")]
    public class DriverController : ControllerBase{
        private static List<Driver> Drivers = new List<Driver>(){
            new Driver{Id=1, Full_name = "lorem", Phone_number= "987987", Created_at= "rabu 21/02/2020", Updated_at="now"},
            new Driver{Id=2, Full_name = "ipsum", Phone_number= "567576", Created_at= "kamis 22/02/2020", Update_at="now"}
        } 
    };

    private readonly ILogger<DriverController> _logger;
    private HttpClient _client;

    public DriverController(ILogger<DriverController> logger, HttpClient client)
    {
        _logger = logger;
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResut> Get()
    {
        var result = await _client.GetStringAync("/driver");
        Console.WriteLine(result);
        return Ok(new {message = "success retrieve data", status = true, data = Drivers });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new {message="success retrieve data", status= true, data = Drivers.Find(dataidnya => dataidnya.Id == id)});

    }
    [HttpPost]
    public IActionResult DriversAdd(DriversRequest driver)
    {
        var driverAdd = new Customer() { Id= driver.Id , Full_name = driver.Full_name, Phone_number = driver.Phone_number, Created_at = driver.Created_at , Update_at = driver.Created_at };
        Drivers.Add(driverAdd);
        return Ok(new { data = Drivers });

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        Driver driver = driver.Find(id);
        if (driver == null)
        {
            return HttpNotFound();
        }
        Driver.Remove(driver);
        Driver.SaveChanges();
        return Ok(new {data=Drivers});
    }

    [HttpPut("{id}")]
    public IActionResult PutById(int id)
    {
        Driver driver = driver.Find(id);
        var driverPut = new Driver() { Id= driver.Id , Full_name = driver.Full_name, Phone_number = driver.Phone_number, Created_at = driver.Created_at , Update_at = driver.Created_at };
        Drivers.Add(driverPut);
        return Ok(new { data = Drivers });
    }

}
