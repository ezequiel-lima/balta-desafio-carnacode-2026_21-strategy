using DesignPatternChallenge;

namespace Challenge
{
    public class LocalShippingCalculator : ICalculateShipping
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 0;

            cost = 8.00m;
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

        public int GetDeliveryTime(ShippingInfo info)
        {
            return 1;
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return info.Destination.Contains("São Paulo-SP");
        }

        public void GetInfo(ShippingInfo info)
        {
            Console.WriteLine($"\n=== Calculando Frete ===");
            Console.WriteLine($"Transportadora: Local");
            Console.WriteLine($"Origem: {info.Origin}");
            Console.WriteLine($"Destino: {info.Destination}");
            Console.WriteLine($"Peso: {info.Weight}kg");
            Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");
        }
    }
}
