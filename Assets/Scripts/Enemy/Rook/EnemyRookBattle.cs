using System;
using UnityEngine;

public class EnemyRookBattle : EnemyBattleBase<RookState>
{
    private void Start()
    {
        m_hitTransforms = new();
        m_effects = new();
        m_hitTransforms.Add(RookState.Dash, transform.Find("AttackTransform"));
        m_effects.Add(transform.Find("DashEffect").GetComponent<UnityEngine.VFX.VisualEffect>());

        m_hitEffect = transform.Find("HitEffect").GetComponent<UnityEngine.VFX.VisualEffect>();
    }
}