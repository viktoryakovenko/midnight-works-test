using Services;
using Services.StaticData;
using StaticData.Currencies;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CurrenciesUI : MonoBehaviour
    {
        [SerializeField] private CurrencyPresenter _coinsPresenter;
        [SerializeField] private CurrencyPresenter _diamondsPresenter;

        private CurrenciesStaticDataService _currenciesService;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _currenciesService = ServiceLocator.GetService<CurrenciesStaticDataService>();

            SetUpPresenter(CurrencyTypeId.Coins, _coinsPresenter);
            SetUpPresenter(CurrencyTypeId.Diamonds, _diamondsPresenter);
        }

        private void SetUpPresenter(CurrencyTypeId currencyTypeId, CurrencyPresenter presenter)
        {
            var currencyData = _currenciesService.ForCurrency(currencyTypeId);

            presenter.SetAmount(currencyData.Amount);
            presenter.SetSprite(currencyData.Sprite);
        }
    }
}
