using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MenuControllerBase
{
    [Header("Menus")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    protected override void Start()
    {
        base.Start();
        
        Controls.SubscribeToAction("Pause", EndPlay);

        stack.Push(mainMenu);
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
}
