using Data;
using Services.PersistentProgress;
using Services.SaveLoad;

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

            progress.CurrenciesData.Coins = 0;
            progress.CurrenciesData.Diamonds = 0;

            return progress;
        }
    }
}
