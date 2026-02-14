using DesignPatternChallenge;

namespace Challenge
{
    public class FedexShippingCalculator : ICalculateShipping
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 0;

            cost = 30.00m;
            cost += info.Weight * 5.00m;

            if (info.IsExpress)
                cost *= 1.8m;

            if (info.Destination.Contains("Norte") || info.Destination.Contains("Nordeste"))
                cost += 20.00m;

            Console.WriteLine($"→ Cálculo FedEx: R$ {cost:N2}");

            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return info.IsExpress ? 2 : 5;
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return info.Weight <= 50;
        }

        public void GetInfo(ShippingInfo info)
        {
            Console.WriteLine($"\n=== Calculando Frete ===");
            Console.WriteLine($"Transportadora: Fedex");
            Console.WriteLine($"Origem: {info.Origin}");
            Console.WriteLine($"Destino: {info.Destination}");
            Console.WriteLine($"Peso: {info.Weight}kg");
            Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");
        }
    }
}
