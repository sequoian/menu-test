using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Controls : MonoBehaviour
{
    public static PlayerInput input {get; private set;}

    void Awake()
    {
        if (input != null)
        {
            Debug.LogError("Cannot instantiate more than one instance of PlayerInput.");
            return;
        }

        input = GetComponent<PlayerInput>();
    }

    public static void SubscribeToAction(string actionName,
        Action<InputAction.CallbackContext> function)
    {
        input.actions[actionName].performed += function;
    }

    public static Vector2 GetAxis(string actionName)
    {
        return input.actions[actionName].ReadValue<Vector2>();
    }

    public static bool GetButton(string actionName)
    {
        return input.actions[actionName].ReadValue<float>() > 0f;
    }
 
    public static bool GetButtonDown(string actionName)
    {
        return input.actions[actionName].WasPressedThisFrame();
    }
 
    public static bool GetButtonUp(string actionName)
    {
        return input.actions[actionName].WasReleasedThisFrame();
    }
}
