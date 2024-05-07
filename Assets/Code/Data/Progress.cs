using System;

namespace Data
{
    [Serializable]
    public class Progress
    {
        public AllMarketsData AllMarketsData;
        public CurrenciesData CurrenciesData;

        public Progress()
        {
            AllMarketsData = new AllMarketsData();
            CurrenciesData = new CurrenciesData();
        }
    }
}
