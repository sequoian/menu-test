using UnityEngine;

public class MenuController : MenuControllerBase
{
    [Header("Menus")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    protected override void Start()
    {
        base.Start();
        
        stack.Push(mainMenu);
    }

    public void OptionsMenu()
    {
        stack.Push(optionsMenu);
    }
}
