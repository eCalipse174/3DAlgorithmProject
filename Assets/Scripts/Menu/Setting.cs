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

    public Slider bgmSlider;
    public Slider sfxSlider;

    public Image bgmButton;
    public Image sfxButton;

    [Header("MuteButton Sprites")]
    public Sprite SFXButtonSprite;
    public Sprite SFXButtonMutedSprite;
    public Sprite BGMButtonSprite;
    public Sprite BGMButtonMutedSprite;

    private void Awake()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        audioMixer = SoundManager.Instance.audioMixer;
    }


    private void SetBGMVolume(float value)
    {
        bgmVolume = value;
        if (!isBGMMute)
            audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(value) * 20);
    }

    private void SetSFXVolume(float value)
    {
        sfxVolume = value;
        if (!isSFXMute)
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }

    public void SetBGMMute()
    {
        if (!isBGMMute)
        {
            isBGMMute = true;
            audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(0.0001f) * 20);

            bgmButton.sprite = BGMButtonMutedSprite;
        }
        else
        {
            isBGMMute = false;
            audioMixer.SetFloat(MIXER_BGM, Mathf.Log10(bgmVolume) * 20);

            bgmButton.sprite = BGMButtonSprite;
        }
    }

    public void SetSFXMute()
    {
        if (!isSFXMute)
        {
            isSFXMute = true;
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(0.0001f) * 20);

            sfxButton.sprite = SFXButtonMutedSprite;
        }
        else
        {
            isSFXMute = false;
            audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(sfxVolume) * 20);

            sfxButton.sprite = SFXButtonSprite;
        }
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
