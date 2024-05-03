using StaticData.Markets;

namespace Services.StaticData
{
    public interface IMarketsStaticDataService
    {
        MarketStaticData ForMarket(MarketTypeId marketTypeId);
        void LoadMarkets();
    }
}
