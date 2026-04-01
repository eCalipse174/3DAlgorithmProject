using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private static PauseManager instance;
    public static PauseManager Instance {  get { return instance; } }

    private bool m_isPause;
    public bool IsPause => m_isPause;

    private void Awake()
    {
        instance = this;
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch(m_isPause)
            {
                case false:
                    Pause();
                    break;
                case true:
                    Cancel();
                    break;
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        m_isPause = true;
        Cursor.lockState = CursorLockMode.None;
        PausePopup.Instance.OpenPopup();
    }

    public void Cancel()
    {
        if (!m_isPause) return;

        Time.timeScale = 1f;
        m_isPause = false;
        Cursor.lockState = CursorLockMode.Locked;
        PausePopup.Instance.ClosePopup();
    }

    public void DestroyInstance()
    {
        instance = null;
        Destroy(gameObject);
    }
}
