using StaticData.Currencies;
using System;

namespace Data
{
    [Serializable]
    public class CurrenciesData
    {
        public SerializableDictionary<CurrencyTypeId, int> Currencies;

        public CurrenciesData() 
        {
            Currencies = new SerializableDictionary<CurrencyTypeId, int>();
        }
    }
}
