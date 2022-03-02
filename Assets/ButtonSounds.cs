using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IMoveHandler, IPointerEnterHandler
{
    public string audioSourceTag;

    AudioSource audioSource;

    void Awake()
    {
        GameObject sourceObject = GameObject.FindGameObjectWithTag(audioSourceTag);
        audioSource = sourceObject.GetComponent<AudioSource>();
    }

    public void OnMove(AxisEventData eventData)
    {
        // Play sound only if the selection moved.
        if (EventSystem.current.currentSelectedGameObject != gameObject)
        {
            PlaySound();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySound();
    }

    void PlaySound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
