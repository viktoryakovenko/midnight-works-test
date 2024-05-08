using Services;
using Services.Bank;
using Services.PersistentProgress;
using UnityEngine;

namespace Logic.Markets
{
    [RequireComponent(typeof(MarketIncome))]
    public class MarketUpgrade : MonoBehaviour
    {
        private IBankService _bankService;
        private IPersistentProgressService _progressService;
        private MarketIncome _marketIncome;
        private int _level;
        private int _upgradeCost;
        private string _id;

        private void Awake()
        {
            _bankService = ServiceLocator.GetService<IBankService>();
            _progressService = ServiceLocator.GetService<IPersistentProgressService>();
            _marketIncome = GetComponent<MarketIncome>();
        }

        public void Initialize(int level, int upgradeCost, string id)
        {
            _level = level;
            _upgradeCost = upgradeCost;
            _id = id;
            _marketIncome.SetIncome(_level * _marketIncome.BaseIncome);
        }

        public void Upgrade()
        {
            _level++;
            _bankService.WithdrawCoins(_upgradeCost * _level);
            _marketIncome.SetIncome(_level * _marketIncome.BaseIncome);

            _progressService.Progress.MarketsData.Find(x => x.Id == _id).CurrentLevel = _level;
        }
    }
}
