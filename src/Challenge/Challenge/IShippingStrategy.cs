using DesignPatternChallenge;

namespace Challenge
{
    public interface IShippingStrategy
    {
        decimal Calculate(ShippingInfo info);
        int GetDeliveryTime(ShippingInfo info);
        bool IsAvailable(ShippingInfo info);
    }
}
