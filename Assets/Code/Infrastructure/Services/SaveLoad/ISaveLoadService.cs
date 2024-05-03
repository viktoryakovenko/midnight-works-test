using Data;

namespace Services.SaveLoad
{
    public interface ISaveLoadService
    {
        Progress LoadProgress();
        void SaveProgress();
    }
}