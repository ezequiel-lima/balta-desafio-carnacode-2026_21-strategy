using DesignPatternChallenge;

namespace Challenge
{
    public class LocalShippingCalculator : IShippingStrategy
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 8.00m;
            cost += info.Weight * 1.50m;

            if (info.IsExpress)
                Console.WriteLine("   ℹ️ Transportadora local sempre entrega rápido");

            if (!info.Destination.Contains("São Paulo-SP"))
            {
                Console.WriteLine("   ❌ Não atende esta região!");
                return 0;
            }

            Console.WriteLine($"→ Cálculo Local: R$ {cost:N2}");
            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info) => 1;       
        public bool IsAvailable(ShippingInfo info) => info.Destination.Contains("São Paulo-SP");
    }
}
