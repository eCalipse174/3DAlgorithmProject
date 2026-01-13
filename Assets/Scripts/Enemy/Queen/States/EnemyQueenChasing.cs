using System;
using System.Collections;
using UnityEngine;

public class EnemyQueenChasing : EnemyQueenStateBase
{
    private Transform m_transform;
    private float m_stopDistance;
    private float m_backStepDistance;

    public EnemyQueenChasing(EnemyQueenStateMachine pStateMachine, EnemyQueenBehaviourInfo pInfo, float pStopDistance, float pBackStepDistance) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
        m_stopDistance = pStopDistance;
        m_backStepDistance = pBackStepDistance;
    }

    public override void Enter()
    {
        Chase();
    }

    private void Chase()
    {
        var targetPos = PlayerObject.transform.position;
        targetPos.y = m_transform.position.y;

        Vector3 start = m_transform.position;
        Vector3 dir = (targetPos - start).normalized;

        Vector3 adjustedTarget = targetPos - dir * m_stopDistance;

        QueenBattle.PlayEffect((int)QueenAttack.Chase);
        QueenBattle.StartCoroutine(ChaseRoutine(adjustedTarget));

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

            if (Vector3.Distance(m_transform.position, PlayerObject.transform.position) < m_backStepDistance)
            {
                QueenStateMachine.ChangeState(QueenState.BackStep);
                yield break;
            }

            yield return null;
        }

        m_transform.position = pTargetPos;

        QueenStateMachine.ChangeState(QueenState.ComboAttack);
    }
}