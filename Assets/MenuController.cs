using UnityEngine;

[RequireComponent(typeof(MenuStack))]
public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;

    MenuStack stack;

    void Start()
    {
        stack = GetComponent<MenuStack>();

        stack.Push(mainMenu);
    }

    public void OptionsMenu()
    {
        stack.Push(optionsMenu);
    }
}
