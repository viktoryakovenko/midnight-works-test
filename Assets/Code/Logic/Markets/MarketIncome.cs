using Services;
using Services.Bank;
using Services.PersistentProgress;
using System;
using System.Collections;
using UnityEngine;

namespace Logic.Markets
{
    public class MarketIncome : MonoBehaviour
    {
        public event Action<int> OnIncome;
        public int BaseIncome => _baseIncome;

        private IBankService _bankService;
        private IPersistentProgressService _persistentProgressService;
        private int _baseIncome;
        private int _currentIncome;
        private int _waitTime;

        private void Awake()
        {
            _bankService = ServiceLocator.GetService<IBankService>();
            _persistentProgressService = ServiceLocator.GetService<IPersistentProgressService>();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                _bankService.AddCoins(_currentIncome);
                OnIncome?.Invoke(_currentIncome);
                yield return new WaitForSeconds(_waitTime);
            }
        }

        private void OnEnable()
        {
            _bankService.OnCoinsChanged += UpdateCoins;
        }

        private void OnDisable()
        {
            _bankService.OnCoinsChanged -= UpdateCoins;
        }

        public void Initialize(int baseIncome, int period)
        {
            _baseIncome = baseIncome;
            _waitTime = period;
            _currentIncome = baseIncome;
        }

        public void SetIncome(int currentIncome)
        {
            _currentIncome = currentIncome;
        }

        private void UpdateCoins(int amount)
        {
            _persistentProgressService.Progress.CurrenciesData.Coins = amount;
        }
    }
}
