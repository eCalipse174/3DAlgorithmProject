using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject menu;

    AudioMixer audioMixer;

    const string MIXER_BGM = "BGMVolume";
    const string MIXER_SFX = "SFXVolume";

    float bgmVolume = 1.0f;
    float sfxVolume = 1.0f;
    bool isBGMMute = false;
    bool isSFXMute = false;

    float sensitivity = 1.0f;

    public Slider bgmSlider;
    public Slider sfxSlider;

    public Slider sensitivitySlider;

    private void Awake()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    private void Start()
    {
        audioMixer = SoundManager.Instance.audioMixer;

        bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);

        bgmSlider.value = bgmVolume;
        sfxSlider.value = sfxVolume;
        sensitivitySlider.value = sensitivity;
    }


    private void SetBGMVolume(float value)
    {
        bgmVolume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);

        if (!isBGMMute)
        {
            float v = Mathf.Clamp(value, 0.0001f, 1f);
            audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(v) * 20);
        }
    }

    private void SetSFXVolume(float value)
    {
        sfxVolume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);

        if (!isSFXMute)
        {
            float v = Mathf.Clamp(value, 0.0001f, 1f);
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(v) * 20);
        }
    }

    public void SetBGMMute()
    {
        if (!isBGMMute)
        {
            isBGMMute = true;
            audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(0.0001f) * 20);

        }
        else
        {
            isBGMMute = false;
            audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(bgmVolume) * 20);

        }
    }

    public void SetSFXMute()
    {
        if (!isSFXMute)
        {
            isSFXMute = true;
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(0.0001f) * 20);

        }
        else
        {
            isSFXMute = false;
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxVolume) * 20);

        }
    }

    public void SetSensitivity(float value)
    {
        GameObject.Find("Player").GetComponent<PlayerCamera>().SetSensitivity(value);
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
