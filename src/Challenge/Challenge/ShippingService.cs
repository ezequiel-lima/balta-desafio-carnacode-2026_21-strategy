using DesignPatternChallenge;

namespace Challenge
{
    public class ShippingService
    {
        private IShippingStrategy _strategy;

        public ShippingService() { }

        public ShippingService(IShippingStrategy calculateShipping)
        {
            _strategy = calculateShipping;
        }

        public void SetStrategy(IShippingStrategy calculateShipping)
        {
            _strategy = calculateShipping;
        }

        public decimal Calculate(ShippingInfo info) => _strategy.Calculate(info);
        public int GetDeliveryTime(ShippingInfo info) => _strategy.GetDeliveryTime(info);
        public bool IsAvailable(ShippingInfo info) => _strategy.IsAvailable(info);

        public void PrintShippingHeader(ShippingInfo info, string carrierName)
        {
            Console.WriteLine($"\n=== Calculando Frete ===");
            Console.WriteLine($"Transportadora: {carrierName}");
            Console.WriteLine($"Origem: {info.Origin}");
            Console.WriteLine($"Destino: {info.Destination}");
            Console.WriteLine($"Peso: {info.Weight}kg");
            Console.WriteLine($"Expresso: {(info.IsExpress ? "Sim" : "Não")}");
        }
    }
}
