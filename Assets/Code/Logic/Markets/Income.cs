using Services;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData.Currencies;
using StaticData.Markets;
using System.Collections;
using UnityEngine;

namespace Logic.Markets
{
    public class Income : MonoBehaviour
    {
        private int _income;
        private WaitForSeconds _waitTime;
        private int _currentGold;
        private IMarketsStaticDataService _marketsDataService;

        private IEnumerator Start()
        {
            _marketsDataService = ServiceLocator.GetService<IMarketsStaticDataService>();
            MarketStaticData marketData = _marketsDataService.ForMarket(MarketTypeId.Bakery);
            Initialize(marketData.BaseIncome, marketData.BaseTime);

            while (true)
            {
                _currentGold += _income;
                Debug.Log("Total Gold: $" + _currentGold);
                yield return _waitTime;
            }
        }

        public void Initialize(int income, int period)
        { 
            _income = income;
            _waitTime = new WaitForSeconds(period);
            _currentGold = ServiceLocator.GetService<IPersistentProgressService>().Progress.CurrenciesData.Currencies[CurrencyTypeId.Coins];
        }
    }
}
