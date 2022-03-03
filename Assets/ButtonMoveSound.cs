using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonMoveSound : MonoBehaviour, IMoveHandler, IPointerEnterHandler
{
    [SerializeField] string audioSourceTag;

    AudioSource audioSource;

    void Awake()
    {
        GameObject sourceObject = GameObject.FindGameObjectWithTag(audioSourceTag);
        audioSource = sourceObject.GetComponent<AudioSource>();
    }

    public void OnMove(AxisEventData eventData)
    {
        // Play sound only if the selection moved using keyboard or gamepad.
        if (EventSystem.current.currentSelectedGameObject != gameObject)
        {
            PlaySound();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Play sound if the moused over.
        if (GetComponent<Button>().interactable)
        {
            PlaySound();
        }
    }

    void PlaySound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
