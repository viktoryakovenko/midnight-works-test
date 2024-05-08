using Data;
using Infrastructure.Factory;
using Services;
using Services.PersistentProgress;
using StaticData.Markets;
using UnityEngine;

namespace Logic
{
    public class MarketSpawner : MonoBehaviour
    {
        public MarketTypeId MarketTypeId;
        public GameObject BuyButtonHandler;

        private string _id;
        private IGameFactory _factory;
        private Progress _progress;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = ServiceLocator.GetService<IGameFactory>();
            _progress = ServiceLocator.GetService<IPersistentProgressService>().Progress;

            LoadProgress();
        }

        private void LoadProgress()
        {
            if (_progress.MarketsData.Find(x => x.Id == _id)?.CurrentLevel > 0)
                Spawn();
            else
                ShowBuyButton();
        }

        private void Spawn()
        {
            GameObject market = _factory.CreateMarket(MarketTypeId, transform);
        }

        private void ShowBuyButton()
        {
            GameObject buyButton = Instantiate(BuyButtonHandler, transform);
            buyButton.GetComponent<BuyButtonHandler>().Initialize(MarketTypeId, transform, _id);
        }
    }
}
