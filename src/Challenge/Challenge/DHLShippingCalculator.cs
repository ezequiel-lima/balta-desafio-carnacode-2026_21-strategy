using DesignPatternChallenge;

namespace Challenge
{
    public class DHLShippingCalculator : IShippingStrategy
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 25.00m;
            cost += info.Weight * 4.50m;

            if (info.Weight > 10)
                cost += (info.Weight - 10) * 2.00m;

            if (info.IsExpress)
                cost += 35.00m;

            Console.WriteLine($"→ Cálculo DHL: R$ {cost:N2}");
            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info) => info.IsExpress ? 1 : 4;       
        public bool IsAvailable(ShippingInfo info) => info.Weight <= 50;      
    }
}
