using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public AudioMixer audioMixer;

    [Header("BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    private AudioSource bgmPlayer;
    private Bgm currentBgm;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    private int channelIndex;
    private AudioSource[] sfxPlayers;

    public const string MIXER_BGM = "BGM";
    public const string MIXER_SFX = "SFX";

    public enum Sfx
    {
        Attack1,
        Attack2,
        Attack3,
        Skill_A,
        Skill_B,

        Pawn,
        Knight,
        Rook,
        Bishop_A,
        Bishop_B,
        QueenSlash,
        QueenBurst,

        Hit,
        Hurt,
        DieEnemy,
    }

    public enum Bgm
    {
        Title,
        Battle,
        Noise,
    }

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Init();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ChangeBGM(Bgm.Title);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (var player in sfxPlayers)
        {
            player.Stop();
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
            ChangeBGM(Bgm.Title);
    }

    private void Init()
    {
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = true;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.outputAudioMixerGroup = audioMixer.FindMatchingGroups(MIXER_BGM)[0];

        GameObject sfxObject = new("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].loop = false;
            sfxPlayers[i].volume = sfxVolume;
            sfxPlayers[i].outputAudioMixerGroup = audioMixer.FindMatchingGroups(MIXER_SFX)[0];
        }
    }

    public void ChangeBGM(Bgm bgm)
    {
        //if (bgm == currentBgm)
            //return;

        currentBgm = bgm;

        bgmPlayer.Stop();
        bgmPlayer.clip = bgmClips[(int)bgm];
        bgmPlayer.Play();
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopindex = (index + channelIndex) % sfxPlayers.Length;
            if (sfxPlayers[loopindex].isPlaying)
                continue;

            channelIndex = loopindex;
            sfxPlayers[loopindex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopindex].Play();
            break;
        }
    }

    public void StopSfx(Sfx sfx)
    {
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            if (sfxPlayers[i].clip == sfxClips[(int)sfx])
                sfxPlayers[i].Stop();
        }
    }
}
