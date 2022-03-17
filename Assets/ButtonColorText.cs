using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonColorText : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] Color selectColor;
    
    Text buttonText;
    Color originalColor;

    void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
        originalColor = buttonText.color;
    }

    void OnDisable()
    {
        buttonText.color = originalColor;
    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonText.color = selectColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        OnDisable();
    }
}
