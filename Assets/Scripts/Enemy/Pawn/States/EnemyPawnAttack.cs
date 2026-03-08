using System;
using System.Collections;
using UnityEngine;

public class EnemyPawnAttack : EnemyPawnStateBase
{
    public EnemyPawnAttack(EnemyPawnStateMachine pStateMachine, EnemyPawnBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PawnBattle.StartCoroutine(Do());
    }

    private IEnumerator Do()
    {
        yield return null;

        PawnBattle.PlayEffect(0);
        yield return new WaitForSeconds(Info.EffectDelay);
        PawnBattle.Hit(Info, 0);
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Pawn);

        yield return new WaitForSeconds(Info.AfterDelay);
        PawnStateMachine.ChangeState(PawnState.Chasing);
    }
}