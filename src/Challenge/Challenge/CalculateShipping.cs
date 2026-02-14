using DesignPatternChallenge;

namespace Challenge
{
    public class CalculateShipping
    {
        private ICalculateShipping _calculateShipping;

        public CalculateShipping()
        {
            
        }

        public CalculateShipping(ICalculateShipping calculateShipping)
        {
            _calculateShipping = calculateShipping;
        }

        public void SetStrategy(ICalculateShipping calculateShipping)
        {
            _calculateShipping = calculateShipping;
        }

        public decimal Calculate(ShippingInfo info)
        { 
            return _calculateShipping.Calculate(info); 
        }

        public int GetDeliveryTime(ShippingInfo info)
        {
            return _calculateShipping.GetDeliveryTime(info);
        }

        public bool IsAvailable(ShippingInfo info)
        {
            return _calculateShipping.IsAvailable(info);
        }

        public void GetInfo(ShippingInfo info)
        {
            _calculateShipping.GetInfo(info);
        }
    }
}
