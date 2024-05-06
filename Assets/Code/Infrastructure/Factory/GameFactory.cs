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

        /*public GameObject CreateNPC(MonsterTypeId typeId, Transform parent)
        {
            HeroGameObject = InstantiateRegistered(AssetPath.HeroPath, at.transform.position);
            return HeroGameObject;
        }*/

        public GameObject CreateMarket(MarketTypeId typeId, Transform parent)
        {
            MarketStaticData marketData = _marketsDataService.ForMarket(typeId);
            GameObject market = Object.Instantiate(marketData.Prefab, parent.position, marketData.Prefab.transform.rotation, parent);

            //int currentLevel = _progressService.Progress.MarketData.

            //Income income = market.GetComponent<Income>();
            //income.Initialize(marketData.BaseIncome, marketData.BaseTime);
            Debug.Log("init!");

            return market;
        }
    }
}
