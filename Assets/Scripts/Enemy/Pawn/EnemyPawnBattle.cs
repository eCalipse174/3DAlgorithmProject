using System;
using UnityEngine;

public class EnemyPawnBattle : EnemyBattleBase<PawnState>
{
    private void Start()
    {
        m_hitTransforms = new();
        m_effects = new();
        m_hitTransforms.Add(PawnState.Attack, transform.Find("AttackTransform"));
        m_effects.Add(transform.Find("AttackEffect").GetComponent<UnityEngine.VFX.VisualEffect>());

        m_hitEffect = transform.Find("HitEffect").GetComponent<UnityEngine.VFX.VisualEffect>();
    }
}