using DesignPatternChallenge;

namespace Challenge
{
    public interface ICalculateShipping
    {
        decimal Calculate(ShippingInfo info);
        int GetDeliveryTime(ShippingInfo info);
        bool IsAvailable(ShippingInfo info);
        void GetInfo(ShippingInfo info);
    }
}
