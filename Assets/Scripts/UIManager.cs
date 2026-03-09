using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    private Image m_hpGauge;
    private Text m_stageText;

    private Image m_black;

    private float m_currentHpRatio;
    private int m_currentStage;

    private bool m_isFading;

    private bool m_isGame;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_currentHpRatio = 1;
        m_currentStage = 0;
        m_isGame = true;

        StartStage();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (m_isGame)
            StartStage();
        else
        {
            StartCoroutine(HideBlack());
        }
    }

    private void StartStage()
    {
        Debug.Log("StartStage");

        m_black = GameObject.Find("Black").GetComponent<Image>();
        m_hpGauge = GameObject.Find("HpGauge").GetComponent<Image>();
        m_stageText = GameObject.Find("CurrentStageText").GetComponent<Text>();

        ShowHp(m_currentHpRatio);
        ShowStage(m_currentStage);

        StartCoroutine(HideBlack());
    }

    public void SetStage(int pStage)
    {
        m_currentStage = pStage;
    }

    public void ShowHp(float pRatio)
    {
        m_currentHpRatio = pRatio;
        m_hpGauge.fillAmount = pRatio;
    }

    public void ShowStage(int pStage)
    {
        m_currentStage = pStage;
        m_stageText.text = "Stage " + (pStage + 1).ToString();
    }

    public IEnumerator NextStage()
    {
        m_isFading = true;
        StartCoroutine(ShowBlack());
        yield return new WaitUntil(() => !m_isFading);
        GameManager.Instance.NextStage();
    }

    private IEnumerator ShowBlack()
    {
        float duration = 0.7f;
        Color color = m_black.color;
        float elapsed = 0f;

        color.a = 0f;
        m_black.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            color.a = t;
            m_black.color = color;

            yield return null;
        }

        color.a = 1f;
        m_black.color = color;

        m_isFading = false;
    }

    private IEnumerator HideBlack()
    {
        m_black = GameObject.Find("Black").GetComponent<Image>();

        float duration = 0.5f;
        Color color = m_black.color;
        float elapsed = 0f;

        color.a = 1f;
        m_black.color = color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = 1 - Mathf.Clamp01(elapsed / duration);

            color.a = t;
            m_black.color = color;

            yield return null;
        }

        color.a = 0f;
        m_black.color = color;
    }

    public void EndGame()
    {
        m_isGame = false;
    }

    public void DestroyInstance()
    {
        instance = null;
        Destroy(gameObject);
    }
}
