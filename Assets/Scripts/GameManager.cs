using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {  get { return instance; } }

    [SerializeField] private int m_maxStage;

    private List<GameObject> m_enemies = new List<GameObject>();
    public List<GameObject> Enemies => m_enemies;

    private int m_currentStage;
    private float m_currentPlayerHp;
    public float CurrentPlayerHp => m_currentPlayerHp;

    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("GameManager.Start()");
        m_currentStage = 0;
        UIManager.Instance.SetStage(m_currentStage);
        SoundManager.Instance.ChangeBGM(SoundManager.Bgm.Battle);
    }

    public void InitHp(float pPlayerMaxHp)
    {
        if (m_currentStage != 0)
            return;

        m_currentPlayerHp = pPlayerMaxHp;
    }

    public void RegisterEnemy(GameObject pEnemy)
    {
        m_enemies.Add(pEnemy);
    }

    public void DieEnemy(GameObject pEnemy)
    {
        m_enemies.Remove(pEnemy);
        if (m_enemies.Count == 0)
        {
            StartCoroutine(UIManager.Instance.NextStage());
        }
    }

    public void SaveHp(float pHp)
    {
        m_currentPlayerHp = pHp;
    }

    public void NextStage()
    {
        m_currentStage++;
        if (m_currentStage >= m_maxStage)
        {
            Win();
            UIManager.Instance.EndGame();
            return;
        }

        UIManager.Instance.SetStage(m_currentStage);
        SceneManager.LoadScene(m_currentStage + 2); //≈∏¿Ã∆≤æ¿, ∏ﬁ¿Œæ¿
    }

    private void Win()
    {
        Debug.Log("win");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("WinScene");
    }

    public void Defeat()
    {
        Debug.Log("defeat");
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("DefeatScene");
    }

    public void EndGame()
    {
        Debug.Log("EndGame");

        SceneManager.sceneLoaded -= UIManager.Instance.OnSceneLoaded;
        UIManager.Instance.DestroyInstance();
        PauseManager.Instance.DestroyInstance();
        instance = null;
        SceneManager.LoadScene("TitleScene");
        Destroy(gameObject);    
    }
}

class Test
{
    enum State
    {
        Idle,
        Walk,
        Run,
        Jump,
        Attack
    }

    State currentState;

    public void Test_()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;

            case State.Walk:
                Walk();
                break;

            case State.Run:
                Run(); 
                break;

            case State.Jump:
                Jump();
                break;

            case State.Attack:
                Attack(); 
                break;
        }
    }

    void Idle() { }
    void Walk() { }
    void Run() { }
    void Jump() { }
    void Attack() { }
}