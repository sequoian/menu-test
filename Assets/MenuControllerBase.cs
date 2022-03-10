using UnityEngine;
using UnityEngine.InputSystem;

public class MenuControllerBase : MonoBehaviour
{
    [Header("Menu Controller Base")]
    [SerializeField] string cancelString;

    protected MenuStack stack;

    protected virtual void Start()
    {
        stack = new MenuStack();

        Controls.SubscribeToAction(cancelString, OnCancel);
    }

    public MenuStack GetMenuStack()
    {
        return stack;
    }

    void OnCancel(InputAction.CallbackContext context)
    {
        Back();
    }

    public void Back()
    {
        if (stack.Count() > 1)
        {
            // Pop the top menu if it's not the last menu on the stack.
            stack.Pop();
        } 
    }
}
