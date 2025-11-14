using System;
using UnityEngine;

public class EnemyQueenRangeAttack : EnemyQueenStateBase
{
    public EnemyQueenRangeAttack(EnemyQueenStateMachine pStateMachine, EnemyQueenBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        if (QueenBattle.CurrentPhase != 2)
            QueenStateMachine.ChangeState(QueenState.Chasing);
    }
}