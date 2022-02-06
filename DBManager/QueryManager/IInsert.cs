using DBManager.ORM;

namespace DBManager.QueryManager;

public interface IInsert
{
    Task InsertNewCryptocurrency(Cryptocurrency cryptocurrency);
    Task InsertNewGoldCoin(Goldcoin goldCoin);
    Task InsertNewCustomer(Customer customer);
    Task InsertNewSell(Sell sell);
    Task InsertNewBuy(Buy buy);
}