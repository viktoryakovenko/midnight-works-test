using StaticData.Currencies;

namespace Services.StaticData
{
    public interface ICurrenciesStaticDataService
    {
        CurrencyStaticData ForCurrency(CurrencyTypeId currencyTypeId);
        void LoadCurrencies();
    }
}
