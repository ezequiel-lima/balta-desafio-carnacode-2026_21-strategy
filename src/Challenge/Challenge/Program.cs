using Challenge;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Cálculo de Frete ===");

            var calculator = new CalculateShipping();

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

            calculator.SetStrategy(new CorreiosShippingCalculator());
            calculator.GetInfo(shipping1);
            var correiosCost = calculator.Calculate(shipping1);
            var correiosTime = calculator.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {correiosTime} dias úteis\n");

            calculator.SetStrategy(new FedexShippingCalculator());
            calculator.GetInfo(shipping2);
            var fedexCost = calculator.Calculate(shipping2);
            var fedexTime = calculator.GetDeliveryTime(shipping2);
            Console.WriteLine($"Prazo: {fedexTime} dias úteis\n");

            calculator.SetStrategy(new DHLShippingCalculator());
            calculator.GetInfo(shipping1);
            var dhlCost = calculator.Calculate(shipping1);
            var dhlTime = calculator.GetDeliveryTime(shipping1);
            Console.WriteLine($"Prazo: {dhlTime} dias úteis\n");

            calculator.SetStrategy(new LocalShippingCalculator());
            calculator.GetInfo(shipping1);
            var localCost = calculator.Calculate(shipping1);

            Console.WriteLine("\n=== Comparando Opções ===");
            var carriers = new[] { "correios", "fedex", "dhl", "local" };

            foreach (var carrier in carriers)
            {
                switch (carrier.ToLower())
                {
                    case "correios":
                        calculator.SetStrategy(new CorreiosShippingCalculator());
                        break;
                    case "fedex":
                        calculator.SetStrategy(new FedexShippingCalculator());
                        break;
                    case "dhl":
                        calculator.SetStrategy(new DHLShippingCalculator());
                        break;
                    case "local":
                        calculator.SetStrategy(new LocalShippingCalculator());
                        break;
                    default:
                        break;
                }

                if (calculator.IsAvailable(shipping1))
                {
                    calculator.GetInfo(shipping1);
                    var cost = calculator.Calculate(shipping1);
                    var time = calculator.GetDeliveryTime(shipping1);
                }
            }

            Console.WriteLine("\n=== PROBLEMAS ===");
            Console.WriteLine("✗ Switch/case repetido em múltiplos métodos");
            Console.WriteLine("✗ Adicionar transportadora = modificar vários métodos");
            Console.WriteLine("✗ Algoritmos não são intercambiáveis em runtime facilmente");
            Console.WriteLine("✗ Difícil testar cada algoritmo isoladamente");
            Console.WriteLine("✗ Viola Open/Closed Principle");
            Console.WriteLine("✗ Lógica de negócio complexa misturada");
            Console.WriteLine("✗ Não é possível combinar ou decorar algoritmos");

            Console.WriteLine("\n=== Requisitos Não Atendidos ===");
            Console.WriteLine("• Trocar algoritmo em runtime sem recompilar");
            Console.WriteLine("• Adicionar nova transportadora sem modificar código existente");
            Console.WriteLine("• Testar cada algoritmo independentemente");
            Console.WriteLine("• Configurar transportadoras via arquivo/banco de dados");
            Console.WriteLine("• Cliente escolher melhor opção sem conhecer detalhes");
            Console.WriteLine("• Compor múltiplos cálculos (ex: frete + seguro)");
        }
    }
}
