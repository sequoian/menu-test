using UnityEngine;

[RequireComponent(typeof(MenuStack))]
public class MenuCancel : MonoBehaviour
{
    [SerializeField] string cancelString;

    MenuStack menuStack;

    void Start()
    {
        menuStack = GetComponent<MenuStack>();
    }

    void Update()
    {
        if (Input.GetButtonDown(cancelString) && menuStack.Count() > 1)
        {
            // Pop the top menu if it's not the last menu on the stack.
            Back();
        }
    }

    public void Back()
    {
        menuStack.Pop();
    }
}

