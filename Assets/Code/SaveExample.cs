using Services;
using Services.SaveLoad;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    private ISaveLoadService _saveLoadService;

    private void Start()
    {
        _saveLoadService = ServiceLocator.GetService<ISaveLoadService>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            _saveLoadService.SaveProgress();
    }
}
