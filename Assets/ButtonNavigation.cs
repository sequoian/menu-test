using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MenuStack))]
public class ButtonNavigation : MonoBehaviour
{
    [SerializeField] bool mouseOnly;
    [SerializeField] bool useCursorInitially;

    MenuStack stack;
    EventSystem eventSystem;
    bool usingCursor;

    void Start()
    {
        stack = GetComponent<MenuStack>();
        eventSystem = EventSystem.current;
        usingCursor = useCursorInitially;
    }

    void Update()
    {
        // Enable cursor on mouse input.
        bool mouseMoved = Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0;
        bool mousePressed = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
        if (!usingCursor && (mouseMoved || mousePressed))
        {
            usingCursor = true;
            Cursor.visible = true;   
        }

        // Disable cursor on keyboard or gamepad input.
        bool mouseButtons = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
        bool keyboardInput = Input.anyKeyDown && !Input.GetButtonDown("Cancel") && !mouseButtons;
        if (usingCursor && keyboardInput && !mouseOnly)
        {
            usingCursor = false;
            Cursor.visible = false;  
        }

        // Select a button if one is not already selected.
        if (!usingCursor && !stack.Empty() && !eventSystem.currentSelectedGameObject)
        {
            MenuBase menuBase = stack.Peek().GetComponent<MenuBase>();
            if (menuBase.previouslySelectedButton != null)
            {
                // Select the previously selected button.
                eventSystem.SetSelectedGameObject(menuBase.previouslySelectedButton);
            }
            else
            {
                // Select the initial button.
                eventSystem.SetSelectedGameObject(menuBase.initialButton);
            }
        }

        // Select buttons that the cursor is hovering over.
        if (usingCursor && !stack.Empty())
        {
            // Get the pointer data.
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            // Perform a raycast on the current canvas using the pointer data.
            GameObject currentCanvas = stack.Peek();
            List<RaycastResult> results = new List<RaycastResult>();
            GraphicRaycaster raycaster = currentCanvas.GetComponent<GraphicRaycaster>();
            raycaster.Raycast(pointerEventData, results);

            // Select button if the pointer is over it.
            bool buttonTouched = false;
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<Button>())
                {
                    EventSystem.current.SetSelectedGameObject(result.gameObject);
                    buttonTouched = true;
                }
            }

            // Deselect button if the pointer is not over it.
            if (!buttonTouched)
            {
                eventSystem.SetSelectedGameObject(null);
            }
        }

        // Regardless of cursor, keep track of the previously selected button. This allows the
        // keyboard button selection to choose the correct button when, for example, the menu is
        // popped and the previously menu is activated.
        if (!stack.Empty() && eventSystem.currentSelectedGameObject != null)
        {
            stack.Peek().GetComponent<MenuBase>()
                .previouslySelectedButton = eventSystem.currentSelectedGameObject;
        }
    }
}
