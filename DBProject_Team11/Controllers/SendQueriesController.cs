using System.Globalization;
using DBManager.QueryManager;
using Microsoft.AspNetCore.Mvc;

namespace DBProject_Team11.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SendQueriesController : ControllerBase
{
    private readonly ISearch _searcher;

    public SendQueriesController(ISearch searcher)
    {
        _searcher = searcher;
    }


    [HttpGet]
    public IActionResult GetCustomer([FromQuery] string id)
    {
        var client = _searcher.GetCustomer(id);
        if (client is null)
        {
            return Ok(new {Id = id, Status = "Not Found"});
        }

        return Ok(new {ID = client.Customerid, FirstName = client.Firstname, LastName = client.Lastname, 
            Username = client.Username, Password = client.Password, Email = client.Email, MainPhone = client.FirstPhone});
    }
    

    [HttpGet]
    public IActionResult GetCurrentPrices()
    {
        return Ok(_searcher.GetTodayRealPrice());
    }

    [HttpGet]
    public IActionResult GetTopBuyer([FromQuery] int count)
    {
        return Ok(_searcher.GetTopBuyer(count));
    }
    
    [HttpGet]
    public IActionResult GetAllBuys()
    {
        
        var data = _searcher.GetAllBuys().ToList();
        var toSend = data.Select(d => new
        {
            GoodsID = d.Goodsid, BuyerID = d.Accountid,
            DOP = d.Digitalorphysical, QTY = d.Qty,  Payment = d.Payment,
            date = DateTime.Today.AddDays(-3).ToString(CultureInfo.InvariantCulture),
            Successful = d.Successful, Score = d.Score
        });
        return Ok(toSend);
    }

    [HttpGet]
    public IActionResult GetGoods()
    {
        var goods = _searcher.GetAllGoods();
        var toSend = goods.Select(good => new Commodity() 
            { Id = int.Parse(good.Goodsid), Name = good.Name, QTY = good.Qty, Wage = good.Wage })
            .OrderBy(a => a.Id);
        
        return Ok(toSend);
    }
}

internal class Commodity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double? QTY { get; set; }
    public double? Wage { get; set; }
}
