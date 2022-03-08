using UnityEngine;

public class MenuControllerBase : MonoBehaviour
{
    [Header("Menu Controller Base")]
    [SerializeField] string cancelString;

    protected MenuStack stack;

    protected virtual void Start()
    {
        stack = new MenuStack();
    }

    public MenuStack GetMenuStack()
    {
        return stack;
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
