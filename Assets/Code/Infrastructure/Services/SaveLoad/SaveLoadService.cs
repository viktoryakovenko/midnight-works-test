using Data;
using Services.StaticData;
using StaticData.Currencies;
using System.IO;
using UnityEngine;

namespace Services.SaveLoad
{
    public class SaveLoadService
    {
        public void SaveToJson()
        {
            Progress progress = new Progress();

            var currenciesService = ServiceLocator.GetService<CurrenciesStaticDataService>();
            progress.CurrenciesData.Coins = currenciesService.ForCurrency(CurrencyTypeId.Coins).Amount;
            progress.CurrenciesData.Diamonds = currenciesService.ForCurrency(CurrencyTypeId.Diamonds).Amount;

            string json = JsonUtility.ToJson(progress, true);
            Debug.Log(Application.dataPath);
            File.WriteAllText(Application.dataPath + "/Save.json", json);
        }
    }
}
