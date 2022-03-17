using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    [SerializeField] bool saveSettings;
    [SerializeField] AudioMixer audioMixer;

    public float GetVolume(string mixerGroup)
    {
        float volume = 1;
        audioMixer.GetFloat(mixerGroup, out volume);
        return volume;
    }

    public void SetVolume(string mixerGroup, float volume)
    {
        audioMixer.SetFloat(mixerGroup, Mathf.Log10(volume) * 20);
    }

    public bool GetFullscreen()
    {
        return Screen.fullScreen;
    }

    public void SetFullscreen(bool enabled)
    {
        Screen.fullScreen = enabled;
    }

    public void GetResoution(out int width, out int height)
    {
        width = Screen.width;
        height = Screen.height;
    }

    public void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, GetFullscreen());
    }

    public bool GetVSync()
    {
        return QualitySettings.vSyncCount == 1 ? true : false;
    }

    public void SetVSync(bool enabled)
    {
        QualitySettings.vSyncCount = enabled ? 1 : 0;
    }

    public float GetBrightness()
    {
        return Screen.brightness;
    }

    public void SetBrightness(float brightness)
    {
        Screen.brightness = brightness;
    }

    public bool GetCursorLock()
    {
        return Cursor.lockState == CursorLockMode.None ? false : true;
    }

    public void SetCursorLock(bool enabled)
    {
        Cursor.lockState = enabled ? CursorLockMode.Confined : CursorLockMode.None;
    }
}
