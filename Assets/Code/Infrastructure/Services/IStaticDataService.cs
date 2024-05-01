using StaticData;

namespace Services 
{
    public interface IStaticDataService
    {
        MarketStaticData ForMarket(MarketTypeId marketTypeId);
        void LoadMarkets();
    }
}
