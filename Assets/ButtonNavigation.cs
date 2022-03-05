using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ButtonNavigation : MonoBehaviour
{
    [SerializeField] bool useCursorInitially;
    [SerializeField] bool mouseOnly;

    MenuStack stack;
    EventSystem eventSystem;

    StateMachine<NavState> stateMachine;
    NavState mouseState, buttonState;

    void Start()
    {
        stack = GetComponent<MenuControllerBase>().GetMenuStack();
        eventSystem = EventSystem.current;

        mouseState = new NavState(MouseUpdate);
        buttonState = new NavState(ButtonUpdate);
        stateMachine = new StateMachine<NavState>(
            useCursorInitially || mouseOnly ? mouseState : buttonState);
    }

    void Update()
    {
        // Update current state.
        stateMachine.GetState().Update();

        // Regardless of state, keep track of the previously selected button. This allows the
        // keyboard button selection to choose the correct button when, for example, the menu is
        // popped and the previously menu is activated.
        if (!stack.Empty() && eventSystem.currentSelectedGameObject != null)
        {
            stack.Peek().GetComponent<MenuBase>()
                .previouslySelectedButton = eventSystem.currentSelectedGameObject;
        }
    }

    void OnControlsChanged(PlayerInput input)
    {
        Debug.Log(input.currentControlScheme);

        // Prevent this from triggering too early.
        if (stateMachine == null) return;

        // Change the state.
        if (input.currentControlScheme == "Mouse")
        {
            stateMachine.SetState(mouseState);
            Cursor.visible = true;
        }
        else
        {
            stateMachine.SetState(buttonState);
            Cursor.visible = false;
        }
    }

    void MouseUpdate()
    {
        // Select buttons that the cursor is hovering over.
        if (!stack.Empty())
        {
            // Get the pointer data.
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Mouse.current.position.ReadValue();

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
    }

    void ButtonUpdate()
    {
        // Select a button if one is not already selected.
        if (!stack.Empty() && !eventSystem.currentSelectedGameObject)
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
    }

    class NavState : StateBase
    {
        public NavState(StateCallback update)
        {
            Update = update;
        }

        public StateCallback Update = () => {};
    }
}
