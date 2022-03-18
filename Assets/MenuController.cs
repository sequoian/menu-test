using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuController : MenuControllerBase
{
    [Header("Menus")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    SettingsController settingsController;

    protected override void Start()
    {
        base.Start();

        settingsController = GetComponent<SettingsController>();
        
        Controls.SubscribeToAction("Pause", EndPlay);

        stack.Push(mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartPlay()
    {
        stack.Clear();
        Controls.ChangeActionMap("Player");
    }

    public void EndPlay(InputAction.CallbackContext context)
    {
        stack.Push(mainMenu);
        Controls.ChangeActionMap("UI");
    }

    public void OptionsMenu()
    {
        stack.Push(optionsMenu);
    }

    public void ChangeMasterVolume(Slider slider)
    {
        settingsController.SetVolume("MasterVolume", slider.value);
    }

    public void ChangeFullscreen(Toggle toggle)
    {
        settingsController.SetFullscreen(toggle.isOn);
    }

    public void Res1920()
    {
        settingsController.SetResolution(1920, 1080);
    }

    public void Res1280()
    {
        settingsController.SetResolution(1280, 720);
    }
    
    public void Res640()
    {
        settingsController.SetResolution(640, 360);
    }
}
