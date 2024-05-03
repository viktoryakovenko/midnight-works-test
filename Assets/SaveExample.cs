using Services;
using Services.SaveLoad;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    private SaveLoadService _saveLoadService;

    private void Start()
    {
        _saveLoadService = ServiceLocator.GetService<SaveLoadService>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            _saveLoadService.SaveToJson();
    }
}
