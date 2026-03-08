using System;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] protected float m_maxHp;
    [SerializeField] private float m_flinchTime;

    [SerializeField] private VisualEffect m_hurtEffect;

    protected float m_currentHp;

    protected virtual void Start()
    {
        m_currentHp = m_maxHp;
        GameManager.Instance.RegisterEnemy(this.gameObject);
    }

    public virtual void Hurt(float pDamage)
    {
        //경직은state로해야할듯
        m_currentHp -= pDamage;
        //Debug.Log($"{pDamage}대미지 입음, 남은 체력: {m_currentHp}/{m_maxHp}");
        m_hurtEffect.Play();
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Hit);

        if (m_currentHp <= 0)
        {
            GameManager.Instance.DieEnemy(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}