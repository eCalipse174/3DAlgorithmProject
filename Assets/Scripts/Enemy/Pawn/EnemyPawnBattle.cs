using System;
using UnityEngine;

public class EnemyPawnBattle : EnemyBattleBase<PawnState>
{
    private void Start()
    {
        m_hitTransforms = new();
        m_effect = new();
        m_hitTransforms.Add(PawnState.Attack, transform.Find("AttackTransform"));
        m_effect.Add(transform.Find("AttackEffect").GetComponent<UnityEngine.VFX.VisualEffect>());
    }
}