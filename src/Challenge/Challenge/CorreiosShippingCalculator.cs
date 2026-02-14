using DesignPatternChallenge;

namespace Challenge
{
    public class CorreiosShippingCalculator : ICalculateShipping
    {
        public decimal Calculate(ShippingInfo info)
        {
            decimal cost = 0;

            cost = 15.00m;
            cost += info.Weight * 2.50m;

            if (info.IsExpress)
                cost += 25.00m;

            if (info.Origin.Split('-')[1] == info.Destination.Split('-')[1])
                cost *= 0.85m;

            Console.WriteLine($"→ Cálculo Correios: R$ {cost:N2}");

            return cost;
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return info.IsExpress ? 3 : 7;
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return true;
        }

        public void GetInfo(ShippingInfo info)
        {
            Console.WriteLine($"\n=== Calculando Frete ===");
            Console.WriteLine($"Transportadora: Correios");
            Console.WriteLine($"Origem: {info.Origin}");
            Console.WriteLine($"Destino: {info.Destination}");
            Console.WriteLine($"Peso: {info.Weight}kg");
            Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");
        }
    }
}
