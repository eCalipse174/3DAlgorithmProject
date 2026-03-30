using UnityEngine;

public class PausePopup : MonoBehaviour
{
    private static PausePopup instance;
    public static PausePopup Instance {  get { return instance; } }

    [SerializeField] private GameObject m_popup;

    [SerializeField] private GameObject m_main;
    [SerializeField] private GameObject m_setting;

    private void Awake()
    {
        instance = this;
    }

    private void OnDisable()
    {
        instance = null;
        Destroy(gameObject);
    }

    public void OpenPopup()
    {
        m_popup.SetActive(true);
    }

    public void ClosePopup()
    {
        PauseManager.Instance.Cancel();
        m_main.SetActive(true);
        m_setting.SetActive(false);
        m_popup.SetActive(false);
    }

    public void GoToTitle()
    {
        Time.timeScale = 1f;
        GameManager.Instance.EndGame();
    }
}