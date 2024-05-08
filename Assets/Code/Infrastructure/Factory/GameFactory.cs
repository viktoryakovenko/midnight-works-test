using Logic.Markets;
using Services.StaticData;
using StaticData.Markets;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IMarketsStaticDataService _marketsDataService;

        public GameFactory(IMarketsStaticDataService marketsDataService)
        {
            _marketsDataService = marketsDataService;
        }

        public GameObject CreateMarket(MarketTypeId typeId, Transform parent)
        {
            MarketStaticData marketData = _marketsDataService.ForMarket(typeId);
            GameObject market = Object.Instantiate(marketData.Prefab, parent.position, marketData.Prefab.transform.rotation, parent);

            MarketIncome income = market.GetComponent<MarketIncome>();
            income.Initialize(marketData.BaseIncome, marketData.BaseTime);

            return market;
        }
    }
}
