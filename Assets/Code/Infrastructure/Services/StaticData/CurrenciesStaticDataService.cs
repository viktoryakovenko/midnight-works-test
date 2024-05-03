using StaticData.Currencies;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.StaticData
{
    public class CurrenciesStaticDataService : ICurrenciesStaticDataService
    {
        private Dictionary<CurrencyTypeId, CurrencyStaticData> _currencies;

        public CurrencyStaticData ForCurrency(CurrencyTypeId currencyTypeId) =>
            _currencies.TryGetValue(currencyTypeId, out CurrencyStaticData staticData)
                ? staticData
                : null;

        public void LoadCurrencies()
        {
            _currencies = Resources
                .LoadAll<CurrencyStaticData>("StaticData/Currencies")
                .ToDictionary(x => x.CurrencyTypeId, x => x);
        }
    }
}
