using UnityEngine;

public class MenuBase : MonoBehaviour
{
    public GameObject initialButton;
    [HideInInspector] public GameObject previouslySelectedButton;

    void Awake()
    {
        // Make sure all menus are disabled by default.
        gameObject.SetActive(false);
    }
}
