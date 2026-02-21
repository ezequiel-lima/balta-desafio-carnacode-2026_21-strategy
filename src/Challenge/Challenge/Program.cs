using Challenge;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Cálculo de Frete ===");

            var shippingService = new ShippingService();

            var shipping1 = new ShippingInfo
            {
                Origin = "São Paulo-SP",
                Destination = "Rio de Janeiro-RJ",
                Weight = 5.0m,
                IsExpress = false
            };

            var shipping2 = new ShippingInfo
            {
                Origin = "São Paulo-SP",
                Destination = "Manaus-AM",
                Weight = 8.0m,
                IsExpress = true
            };

            var strategies = new Dictionary<string, IShippingStrategy>(StringComparer.OrdinalIgnoreCase)
            {
                { "correios", new CorreiosShippingCalculator() },
                { "fedex", new FedexShippingCalculator() },
                { "dhl", new DHLShippingCalculator() },
                { "local", new LocalShippingCalculator() }
            };

            shippingService.PrintShippingHeader(shipping1, "correios");
            shippingService.SetStrategy(strategies["correios"]);
            var correiosCost = shippingService.Calculate(shipping1);
            var correiosTime = shippingService.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {correiosTime} dias úteis\n");

            shippingService.PrintShippingHeader(shipping2, "fedex");
            shippingService.SetStrategy(strategies["fedex"]);
            var fedexCost = shippingService.Calculate(shipping2);
            var fedexTime = shippingService.GetDeliveryTime(shipping2);
            Console.WriteLine($"Prazo: {fedexTime} dias úteis\n");

            shippingService.PrintShippingHeader(shipping1, "dhl");
            shippingService.SetStrategy(strategies["dhl"]);
            var dhlCost = shippingService.Calculate(shipping1);
            var dhlTime = shippingService.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {dhlTime} dias úteis\n");

            shippingService.PrintShippingHeader(shipping1, "local");
            shippingService.SetStrategy(strategies["local"]);
            var localCost = shippingService.Calculate(shipping1);

            shippingService.PrintShippingHeader(shipping1, "transportadora-nova");
            Console.WriteLine("❌ Transportadora 'transportadora-nova' não suportada!");

            Console.WriteLine("\n=== Comparando Opções ===");
            var carriers = new[] { "correios", "fedex", "dhl", "local" };

            foreach (var carrier in carriers)
            {
                shippingService.SetStrategy(strategies[carrier]);

                if (shippingService.IsAvailable(shipping1))
                {
                    shippingService.PrintShippingHeader(shipping1, carrier);
                    var cost = shippingService.Calculate(shipping1);
                    var time = shippingService.GetDeliveryTime(shipping1);
                }
            }
        }
    }
}
