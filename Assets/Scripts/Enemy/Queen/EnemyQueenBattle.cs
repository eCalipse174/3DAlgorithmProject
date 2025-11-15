using System;
using UnityEngine;

public enum QueenAttack
{
    Combo1,
    Combo2,
    Range,
    Chase
}

public class EnemyQueenBattle : EnemyBattleBase<QueenState>
{
    private float m_currentPhase;
    public float CurrentPhase => m_currentPhase;

    private void Start()
    {
        m_currentPhase = 1;

        m_hitTransforms = new();
        m_effects = new();
        m_hitTransforms.Add(QueenState.ComboAttack, transform.Find("ComboAttackTransform"));
        m_effects.Add(transform.Find("ComboAttackEffect1").GetComponent<UnityEngine.VFX.VisualEffect>());
        m_effects.Add(transform.Find("ComboAttackEffect2").GetComponent<UnityEngine.VFX.VisualEffect>());
        m_effects.Add(transform.Find("RangeAttackEffect").GetComponent<UnityEngine.VFX.VisualEffect>());
        m_effects.Add(transform.Find("ChaseEffect").GetComponent<UnityEngine.VFX.VisualEffect>());

        m_hitEffect = transform.Find("HitEffect").GetComponent<UnityEngine.VFX.VisualEffect>();
    }

    public void ChangePhase()
    {
        m_currentPhase++;
    }
}