using Services;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData.Currencies;
using UnityEngine;

namespace UI
{
    public class CurrenciesUI : MonoBehaviour
    {
        [SerializeField] private CurrencyPresenter _coinsPresenter;
        [SerializeField] private CurrencyPresenter _diamondsPresenter;

        private ICurrenciesStaticDataService _currenciesService;
        private IPersistentProgressService _persistentDataService;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _persistentDataService = ServiceLocator.GetService<IPersistentProgressService>();
            _currenciesService = ServiceLocator.GetService<ICurrenciesStaticDataService>();

            SetUpPresenter(CurrencyTypeId.Coins, _coinsPresenter);
            SetUpPresenter(CurrencyTypeId.Diamonds, _diamondsPresenter);
        }

        private void SetUpPresenter(CurrencyTypeId currencyTypeId, CurrencyPresenter presenter)
        {
            var amount = _persistentDataService.Progress.CurrenciesData.Currencies[currencyTypeId];
            var sprite = _currenciesService.ForCurrency(currencyTypeId).Sprite;

            presenter.SetAmount(amount);
            presenter.SetSprite(sprite);
        }
    }
}
