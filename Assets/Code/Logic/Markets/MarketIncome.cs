using Services;
using Services.Bank;
using System;
using System.Collections;
using UnityEngine;

namespace Logic.Markets
{
    public class MarketIncome : MonoBehaviour
    {
        public event Action<int> OnIncome;

        private IBankService _bankService;
        private int _income;
        private int _waitTime;

        private void Awake()
        {
            _bankService = ServiceLocator.GetService<IBankService>();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                _bankService.AddCoins(_income);
                OnIncome?.Invoke(_income);
                yield return new WaitForSeconds(_waitTime);
            }
        }

        public void Initialize(int income, int period)
        { 
            _income = income;
            _waitTime = period;
        }
    }
}
