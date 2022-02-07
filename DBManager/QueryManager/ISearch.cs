using DBManager.Model;

namespace DBManager.QueryManager;

public interface ISearch
{
    Customer? GetCustomer(string id);

    IEnumerable<TodayPrice> GetTodayRealPrice();

    IEnumerable<TopBuyer> GetTopBuyer(int count);

    IEnumerable<Good> GetAllGoods();
    
    IEnumerable<Buy> GetAllBuys();
}