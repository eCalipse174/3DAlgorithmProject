using UnityEngine;

public class EndSceneButton : MonoBehaviour
{
    public void EndGame()
    {
        GameManager.Instance.EndGame();
    }
}
