using DesignPatternChallenge;

namespace Challenge
{
    public class DHLShippingCalculator : ICalculateShipping
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 0;

            cost = 25.00m;
            cost += info.Weight * 4.50m;

            if (info.Weight > 10)
                cost += (info.Weight - 10) * 2.00m;

            if (info.IsExpress)
                cost += 35.00m;

            Console.WriteLine($"→ Cálculo DHL: R$ {cost:N2}");

            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return info.IsExpress ? 1 : 4;
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return info.Weight <= 50;
        }

        public void GetInfo(ShippingInfo info)
        {
            Console.WriteLine($"\n=== Calculando Frete ===");
            Console.WriteLine($"Transportadora: DHL");
            Console.WriteLine($"Origem: {info.Origin}");
            Console.WriteLine($"Destino: {info.Destination}");
            Console.WriteLine($"Peso: {info.Weight}kg");
            Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");
        }
    }
}
