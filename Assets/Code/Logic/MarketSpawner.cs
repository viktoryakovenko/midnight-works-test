using Data;
using Infrastructure.Factory;
using Services;
using StaticData.Markets;
using UnityEngine;

namespace Logic
{
    public class MarketSpawner : MonoBehaviour
    {
        public MarketTypeId MarketTypeId;
        public GameObject BuyButton;
        public bool Bought => _bought;

        [SerializeField] private bool _bought;
        private string _id;
        private IGameFactory _factory;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = ServiceLocator.GetService<IGameFactory>();

            ShowBuyButton();
        }

        public void LoadProgress(Progress progress)
        {
            if (progress.AllMarketsData.Markets[_id].CurrentLevel > 0)
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
            BuyButton.SetActive(true);
        }
    }
}
