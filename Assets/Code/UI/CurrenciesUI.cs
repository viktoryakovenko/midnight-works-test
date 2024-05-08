using Services;
using Services.Bank;
using System;
using UnityEngine;

namespace UI
{
    public class CurrenciesUI : MonoBehaviour
    {
        [SerializeField] private CurrencyPresenter _coinsPresenter;
        [SerializeField] private CurrencyPresenter _diamondsPresenter;

        private IBankService _bankService;

        private void Awake()
        {
            _bankService = ServiceLocator.GetService<IBankService>();

            Initialize();
        }

        private void OnEnable()
        {
            _bankService.OnCoinsChanged += SetUpCoinsText;
            _bankService.OnDiamondsChanged += SetUpDiamondsText;
        }

        private void OnDisable()
        {
            _bankService.OnCoinsChanged -= SetUpCoinsText;
            _bankService.OnDiamondsChanged -= SetUpDiamondsText;
        }

        private void Initialize()
        {
            SetUpCoinsText(_bankService.Coins);
            SetUpDiamondsText(_bankService.Diamonds);
        }

        private void SetUpCoinsText(int amount)
        {
            _coinsPresenter.SetAmount(amount);
        }

        private void SetUpDiamondsText(int amount)
        {
            _diamondsPresenter.SetAmount(amount);
        }
    }
}
