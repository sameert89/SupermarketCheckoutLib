using IDatabaseLib;
namespace PricesCalcLib
{
    public static class PriceCalculator
    {
        public static double Price(PricesTable p, string input)
        {
            var items = input
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            double totalPrice = 0;

            foreach(var item in items)
            {

                var (itemName, numPurchased) = item;

                var (regularPrice, offerString) = p.priceDict[itemName];

                var (itemsForOffer, offerPrice) = GetOfferFromOfferString(offerString);

                totalPrice += calcOfferPrice(numPurchased, itemsForOffer, offerPrice)
                            + calcRegularPrice(numPurchased, itemsForOffer, regularPrice);
                
            }
            return totalPrice;
        }
        private static double calcOfferPrice(int numPurchased, int itemsForOffer, double offerPrice)
        {
            if (itemsForOffer == 0) return 0;
            else return (numPurchased / itemsForOffer) * offerPrice;
        }
        private static double calcRegularPrice(int numPurchased, int itemsForOffer, double offerPrice)
        {
            if(itemsForOffer == 0) return numPurchased * offerPrice;
            else return (numPurchased % itemsForOffer) * offerPrice;
        }
        private static Tuple<int, double> GetOfferFromOfferString(string offer)
        {
            if(offer == "")
                return new Tuple<int, double>(0, 0); // no offers available
            string[] parts = offer.Split(" for ");
            int quantity = int.Parse(parts[0]);
            double value = double.Parse(parts[1]);
            return new Tuple<int, double>(quantity, value);
        }
    }
}
