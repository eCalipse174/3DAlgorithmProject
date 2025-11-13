using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyBattleBase<T> : MonoBehaviour
    where T : Enum
{
    protected Dictionary<T, Transform> m_hitTransforms;
    protected List<VisualEffect> m_effect;

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
            }
        }
    }

    public void PlayEffect(int pIndex)
    {
        m_effect[pIndex].Play();
    }
}