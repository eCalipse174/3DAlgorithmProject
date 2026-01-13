using System;
using System.Collections;
using UnityEngine;

public class EnemyQueenRangeAttack : EnemyQueenStateBase
{
    private Transform m_transform;

    public EnemyQueenRangeAttack(EnemyQueenStateMachine pStateMachine, EnemyQueenBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
    }

    public override void Enter()
    {
        if (QueenBattle.CurrentPhase != 2)
            QueenStateMachine.ChangeState(QueenState.Chasing);
        else
            QueenBattle.StartCoroutine(Do());
    }

    private IEnumerator Do()
    {
        Vector3 targetPos = PlayerObject.transform.position;
        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);

        QueenBattle.PlayEffect((int)QueenAttack.Range);
        yield return new WaitForSeconds(Info.EffectDelay);
        QueenBattle.Hit(Info, 0);

        yield return new WaitForSeconds(Info.Duration);
        yield return new WaitForSeconds(Info.AfterDelay);
        QueenStateMachine.ChangeState(QueenState.Chasing);
    }
}