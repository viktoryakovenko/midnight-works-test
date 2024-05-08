using Logic.Markets;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData.Markets;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IPersistentProgressService _progressService;
        private IMarketsStaticDataService _marketsDataService;
        private ICurrenciesStaticDataService _currenciesDataService;

        public GameFactory(IMarketsStaticDataService marketsDataService, IPersistentProgressService progressService)
        {
            _marketsDataService = marketsDataService;
            _progressService = progressService;
        }

        public GameObject CreateMarket(MarketTypeId typeId, Transform parent)
        {
            MarketStaticData marketData = _marketsDataService.ForMarket(typeId);
            GameObject market = Object.Instantiate(marketData.Prefab, parent.position, marketData.Prefab.transform.rotation, parent);

            Income income = market.GetComponent<Income>();
            income.Initialize(marketData.BaseIncome, marketData.BaseTime);

            return market;
        }
    }
}
