using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void StartGame()
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
}
