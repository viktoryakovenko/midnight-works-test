using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class Progress
    {
        public List<MarketData> MarketsData;
        public CurrenciesData CurrenciesData;

        public Progress()
        {
            MarketsData = new List<MarketData>();
            CurrenciesData = new CurrenciesData();
        }
    }
}
