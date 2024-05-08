using Logic.Markets;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData.Markets;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IMarketsStaticDataService _marketsDataService;
        private IPersistentProgressService _progressService;

        public GameFactory(IMarketsStaticDataService marketsDataService, IPersistentProgressService progressService)
        {
            _marketsDataService = marketsDataService;
            _progressService = progressService;
        }

        public GameObject CreateMarket(MarketTypeId typeId, Transform parent, string id)
        {
            MarketStaticData marketStaticData = _marketsDataService.ForMarket(typeId);
            GameObject market = Object.Instantiate(marketStaticData.Prefab, parent.position, marketStaticData.Prefab.transform.rotation, parent);
            var marketData = _progressService.Progress.MarketsData.Find(x => x.Id == id);
            int currentLevel;

            if (marketData != null)
                currentLevel = marketData.CurrentLevel;
            else
                currentLevel = 1;

            MarketIncome income = market.GetComponent<MarketIncome>();
            income.Initialize(marketStaticData.BaseIncome, marketStaticData.BaseTime);

            MarketUpgrade marketUpgrade = market.GetComponent<MarketUpgrade>();
            marketUpgrade.Initialize(currentLevel, marketStaticData.UpgradeCost, id);

            return market;
        }
    }
}
