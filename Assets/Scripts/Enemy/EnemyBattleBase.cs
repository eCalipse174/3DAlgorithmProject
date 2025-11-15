using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyBattleBase<T> : MonoBehaviour
    where T : Enum
{
    protected Dictionary<T, Transform> m_hitTransforms;
    protected List<VisualEffect> m_effects;
    protected VisualEffect m_hitEffect;

    public virtual void Hit(EnemyBehaviourInfoBase<T> pInfo, int pHitIndex)
    {
        Collider[] hits;
        Transform trans = m_hitTransforms[pInfo.State];

        hits = Physics.OverlapSphere(trans.position, pInfo.AreaRadius);
        foreach (var hit in hits)
        {
            // 플레이어 때리기
            if (hit.CompareTag("Player"))
            {
                Debug.Log($"{name}이(가) {hit.name}에게 {pInfo.Hits[pHitIndex]} 데미지!");
                hit.GetComponent<PlayerStat>().Hurt(pInfo.Hits[pHitIndex]);

                m_hitEffect.transform.position = hit.transform.position;
                m_hitEffect.transform.position += new Vector3(0, 2.2f, 0);
                m_hitEffect.Play();
            }
        }
    }

    public void PlayEffect(int pIndex)
    {
        m_effects[pIndex].Play();
    }
}