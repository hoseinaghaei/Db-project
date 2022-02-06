using DBManager.ORM;

namespace DBManager.QueryManager;

public class Insert : IInsert
{
    private readonly DbProjectContext _dbContext;

    public Insert(DbProjectContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InsertNewCryptocurrency(Cryptocurrency cryptocurrency)
    {
        await _dbContext.Cryptocurrencies.AddAsync(cryptocurrency);
    }

    public async Task InsertNewGoldCoin(Goldcoin goldCoin)
    {
        await _dbContext.Goldcoins.AddAsync(goldCoin);
    }

    public async Task InsertNewCustomer(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
    }

    public async Task InsertNewSell(Sell sell)
    {
        await _dbContext.Sells.AddAsync(sell);
    }

    public async Task InsertNewBuy(Buy buy)
    {
        await _dbContext.Buys.AddAsync(buy);
    }
}