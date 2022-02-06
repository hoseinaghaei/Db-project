using DBManager.ORM;

namespace DBManager.QueryManager;

public class Search : ISearch
{
    private readonly DbProjectContext _dbContext;

    public Search(DbProjectContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Customer? GetCustomer(string id)
    {
        return _dbContext.Customers.Find(id);
    }

    public IEnumerable<TodayPrice> GetTodayRealPrice()
    {
        return _dbContext.TodayPrices;
    }

    public IEnumerable<TopBuyer> GetTopBuyer(int count)
    {
        return _dbContext.TopBuyers.Take(count);
    }

    public IEnumerable<Good> GetAllGoods()
    {
        return _dbContext.Goods.OrderBy(a => a.Goodsid);
    }

    public IEnumerable<Buy> GetAllBuys()
    {
        return _dbContext.Buys.ToList();
    }
}