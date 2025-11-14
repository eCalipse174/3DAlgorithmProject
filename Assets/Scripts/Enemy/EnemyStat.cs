using System;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float m_maxHp;
    [SerializeField] private float m_flinchTime;

    [SerializeField] private VisualEffect m_hurtEffect;

    private float m_currentHp;

    private void Start()
    {
        m_currentHp = m_maxHp;
    }

    public void Hurt(float pDamage)
    {
        //경직은state로해야할듯
        m_currentHp -= pDamage;
        Debug.Log($"{pDamage}대미지 입음, 남은 체력: {m_currentHp}/{m_maxHp}");
        m_hurtEffect.Play();

        if (m_currentHp <= 0)
        {
            //끝
            Debug.Log($"{name} 뒤짐");
            gameObject.SetActive(false);
        }
    }
}