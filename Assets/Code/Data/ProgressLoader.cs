using Data;
using Logic;
using Services.PersistentProgress;
using Services.SaveLoad;
using StaticData.Currencies;
using UnityEngine;

namespace Code.Data
{
    public class ProgressLoader
    {
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public ProgressLoader(IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void LoadProgressOrInitNew() =>
            _progressService.Progress =
                _saveLoadService.LoadProgress()
                ?? NewProgress();

        private Progress NewProgress()
        {
            var progress = new Progress();

            progress.CurrenciesData.Currencies[CurrencyTypeId.Coins] = 10;
            progress.CurrenciesData.Currencies[CurrencyTypeId.Diamonds] = 50;

            return progress;
        }
    }
}
