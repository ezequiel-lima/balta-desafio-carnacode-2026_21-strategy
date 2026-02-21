using DesignPatternChallenge;

namespace Challenge
{
    public class FedexShippingCalculator : IShippingStrategy
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 30.00m;
            cost += info.Weight * 5.00m;

            if (info.IsExpress)
                cost *= 1.8m;

            if (info.Destination.Contains("Norte") || info.Destination.Contains("Nordeste"))
                cost += 20.00m;

            Console.WriteLine($"→ Cálculo FedEx: R$ {cost:N2}");
            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info) => info.IsExpress ? 2 : 5;       
        public bool IsAvailable(ShippingInfo info) => info.Weight <= 50;      
    }
}
