using System;

namespace Data
{
    [Serializable]
    public class Progress
    {
        public MarketData MarketData;
        public CurrenciesData CurrenciesData;

        public Progress()
        {
            MarketData = new MarketData();
            CurrenciesData = new CurrenciesData();
        }
    }
}
