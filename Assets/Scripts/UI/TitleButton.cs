using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField] private Image m_black;


    public void StartButton()
    {
        StartCoroutine(ShowBlack());
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene"); 
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }


    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private IEnumerator ShowBlack()
    {
        m_black.gameObject.SetActive(true);

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

        StartGame();
    }
}
