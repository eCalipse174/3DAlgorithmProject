using System;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private float m_maxHp;
    [SerializeField] private float m_flinchTime;

    private float m_currentHp;

    private void Start()
    {
        GameManager.Instance.InitHp(m_maxHp);
        LoadHp();
    }

    private void LoadHp()
    {
        m_currentHp = GameManager.Instance.CurrentPlayerHp;
    }

    public void Hurt(float pDamage)
    {
        //경직은state로해야할듯
        m_currentHp -= pDamage;
        GameManager.Instance.SaveHp(m_currentHp);
        UIManager.Instance.ShowHp(m_currentHp / m_maxHp);
        Debug.Log($"{pDamage}대미지 입음, 남은 체력: {m_currentHp}/{m_maxHp}");

        if (m_currentHp <= 0)
        {
            //끝
            Debug.Log("끝");
            UIManager.Instance.EndGame();
            GameManager.Instance.Defeat();
        }
    }
}