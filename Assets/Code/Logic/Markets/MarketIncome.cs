using System;
using System.Collections;
using UnityEngine;

namespace Logic.Markets
{
    public class MarketIncome : MonoBehaviour
    {
        public event Action<int> OnIncome;

        private int _income;
        private int _waitTime;

        private IEnumerator Start()
        {
            while (true)
            {
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
