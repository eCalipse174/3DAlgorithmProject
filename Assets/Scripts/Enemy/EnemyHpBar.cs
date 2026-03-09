using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    [SerializeField] private Image fill;
    [SerializeField] private GameObject hpBar;

    public void UpdateUI(float ratio)
    {
        hpBar.gameObject.SetActive(true);
        fill.fillAmount = ratio;
    }
}