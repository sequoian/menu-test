using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    void Update()
    {
        if (Controls.GetButtonDown("Jump"))
        {
            Debug.Log("Jump!");
        }
    }
}
