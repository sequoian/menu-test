using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuStack : MonoBehaviour
{
    Stack<GameObject> stack;
    EventSystem eventSystem;

    void Start()
    {
        stack = new Stack<GameObject>();
        eventSystem = EventSystem.current;
    }

    public void Push(GameObject nextMenu)
    {
        // Disable previous menu (if there is one).
        if (!Empty())
        {
            stack.Peek().SetActive(false);
        }
        
        // Enable next menu.
        stack.Push(nextMenu);
        nextMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
    }

    public GameObject Pop()
    {
        // Disable current menu.
        GameObject menu = stack.Pop();
        menu.SetActive(false);
        eventSystem.SetSelectedGameObject(null);

        // Enable previous menu (if there is one).
        if (!Empty())
        {
            stack.Peek().SetActive(true);
        }
        
        // Return the popped menu.
        return menu;
    }

    public GameObject Peek()
    {
        return stack.Peek();
    }

    public int Count()
    {
        return stack.Count;
    }

    public bool Empty()
    {
        return stack.Count == 0;
    }

    public void Clear()
    {
        // Disable each menu in the stack.
        while (stack.Count > 0)
        {
            stack.Pop().SetActive(false);
        }
        
        // Disable buttons.
        eventSystem.SetSelectedGameObject(null);
    }
}
