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
            Debug.LogError("Cannot instantiate more than one instance of PlayerInput");
            return;
        }

        input = GetComponent<PlayerInput>();
    }
}
