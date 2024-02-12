using IDatabaseLib;
using PricesCalcLib;
namespace SupermarketCheckoutLib
{
    public class CheckoutController
    {
        private PricesTable pricesTableObjRef;
        private readonly IDatabase databaseRef;
        public CheckoutController(IDatabase databaseRef)
        {
            this.databaseRef = databaseRef;
            pricesTableObjRef = this.databaseRef.GetPricesTable();
        }
        public double Checkout(string prices)
        {
            pricesTableObjRef = databaseRef.GetPricesTable();
            return PriceCalculator.Price(pricesTableObjRef, prices);
        }

    }
}
