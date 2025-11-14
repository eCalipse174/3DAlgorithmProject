using System;
using System.Collections;
using UnityEngine;

public class EnemyQueenChasing : EnemyQueenStateBase
{
    private Transform m_transform;
    private float m_stopDistance;

    public EnemyQueenChasing(EnemyQueenStateMachine pStateMachine, EnemyQueenBehaviourInfo pInfo, float pStopDistance) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
        m_stopDistance = pStopDistance;
    }

    public override void Enter()
    {
        Chase();
    }

    private void Chase()
    {
        var targetPos = PlayerObject.transform.position;

        Vector3 start = m_transform.position;
        Vector3 dir = (targetPos - start).normalized;

        Vector3 adjustedTarget = targetPos - dir * m_stopDistance;

        QueenBattle.PlayEffect((int)QueenAttack.Chase);
        QueenBattle.StartCoroutine(ChaseRoutine(adjustedTarget));

        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);
    }

    private IEnumerator ChaseRoutine(Vector3 pTargetPos)
    {
        yield return null;

        Vector3 startPos = m_transform.position;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / Info.Duration;
            float easedT = (t >= 1f) ? 1f : 1f - Mathf.Pow(2f, -10f * t);

            m_transform.position = Vector3.Lerp(startPos, pTargetPos, easedT);

            yield return null;
        }

        m_transform.position = pTargetPos;

        QueenStateMachine.ChangeState(QueenState.ComboAttack);
    }
}