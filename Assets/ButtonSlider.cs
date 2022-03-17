using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSlider : MonoBehaviour, IMoveHandler
{
    [SerializeField] int slices;

    Slider slider;

    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void OnMove(AxisEventData eventData)
    {
        if (eventData.moveDir == MoveDirection.Right)
        {
            slider.value += slider.maxValue / slices;
        }
        else if (eventData.moveDir == MoveDirection.Left)
        {
            slider.value -= slider.maxValue / slices;
        }
    }
}
