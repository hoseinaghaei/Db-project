using DBManager;
using DBManager.Model;
using DBManager.QueryManager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DBProject_Team11.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class InsertDataController : ControllerBase
{
    private readonly IInsert _insert;

    public InsertDataController(IInsert insert)
    {
        _insert = insert;
    }

    [HttpPost]
    public async Task<IActionResult> InsertCustomer([FromBody] NewCustomer newCustomer)
    {

        var customer = new Customer()
        {
            CustomerId = newCustomer.Id,
            Firstname = newCustomer.Firstname,
            Lastname = newCustomer.Lastname,
            Username = newCustomer.Username,
            Password = newCustomer.Password,
            FirstPhone = newCustomer.FirstPhone,
            Email = newCustomer.Email
        };
        await _insert.InsertNewCustomer(customer);
        return Ok(customer);
    }
    
    [HttpPost]
    public async Task<IActionResult> InsertBuyRecord([FromBody] NewBuy newBuy)
    {

        var buy = new Buy()
        {
            GoodsId = newBuy.GoodsId,
            AccountId = newBuy.AccountId,
            TransactionCode = Guid.NewGuid().ToString().Substring(2, 8),
            Successful = true,
            DigitalOrPhysical = newBuy.Dop,
            Qty = newBuy.Qty,
            Score = newBuy.Score,
            Sheba = newBuy.Sheba
        };
        await _insert.InsertNewBuy(buy);
        return Ok(buy);
    }

}

public class NewCustomer
{
    public string Id { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Email { get; set; }
    public string? FirstPhone { get; set; }
} 

public class NewBuy
{
    public string GoodsId { get; set; } = null!;
    public string AccountId { get; set; } = null!;
    public string Dop { get; set; } = null!;
    public double Qty { get; set; }
    public int Score { get; set; }

    public string? Sheba { get; set; }
} 