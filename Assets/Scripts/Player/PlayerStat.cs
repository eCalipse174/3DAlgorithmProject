using System;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField] private float m_maxHp;
    [SerializeField] private float m_flinchTime;

    private float m_currentHp;

    private void Start()
    {
        m_currentHp = m_maxHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //아야!
            Hurt(10); //기본 접촉대미지
        }
    }

    public void Hurt(float pDamage)
    {
        //경직은state로해야할듯
        m_currentHp -= pDamage;
        Debug.Log($"{pDamage}대미지 입음, 남은 체력: {m_currentHp}/{m_maxHp}");

        if (m_currentHp <= 0)
        {
            //끝
            Debug.Log("끝");
            GameManager.Instance.EndGame();
        }
    }
}