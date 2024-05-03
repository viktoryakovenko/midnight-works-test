using Data;
using Services.PersistentProgress;
using System.IO;
using UnityEngine;

namespace Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly string SAVE_PATH = Application.dataPath + "/Save.json";

        public void SaveProgress()
        {
            var progress = ServiceLocator.GetService<IPersistentProgressService>().Progress;

            File.WriteAllText(SAVE_PATH, progress.ToJson());
        }

        public Progress LoadProgress() 
        {
            if (File.Exists(SAVE_PATH))
                return File.ReadAllText(SAVE_PATH).ToDeserialized<Progress>();
            else
                return null;
        }
    }
}
