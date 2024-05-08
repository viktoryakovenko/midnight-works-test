using System;
using System.Collections;
using UnityEngine;

namespace Logic.Markets
{
    public class Income : MonoBehaviour
    {
        public event Action<int> OnIncome;

        private int _income;
        private WaitForSeconds _waitTime;

        private IEnumerator Start()
        {
            while (true)
            {
                OnIncome?.Invoke(_income);
                yield return _waitTime;
            }
        }

        public void Initialize(int income, int period)
        { 
            _income = income;
            _waitTime = new WaitForSeconds(period);
        }
    }
}
