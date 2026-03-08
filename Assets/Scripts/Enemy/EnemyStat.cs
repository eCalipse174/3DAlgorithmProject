using System;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] protected float m_maxHp;
    [SerializeField] private float m_flinchTime;

    [SerializeField] private VisualEffect m_hurtEffect;

    protected float m_currentHp;

    private Renderer m_renderer;
    private Material[] m_materials;

    protected virtual void Start()
    {
        m_currentHp = m_maxHp;
        GameManager.Instance.RegisterEnemy(this.gameObject);

        m_renderer = GetComponent<Renderer>();
        m_materials = m_renderer.materials;
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
            StartCoroutine(Dissolve());
        }
    }

    IEnumerator Dissolve()
    {
        float duration = 0.5f;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = time / duration;

            foreach (var mat in m_materials)
            {
                Debug.Log(mat.name);
                mat.SetFloat("_Dissolve", t);
                Debug.Log(mat.HasProperty("_Dissolve"));
            }

            yield return null;
        }

        foreach (var mat in m_materials)
            mat.SetFloat("_Dissolve", 1f);

        GameManager.Instance.DieEnemy(gameObject);
        gameObject.SetActive(false);
    }
}