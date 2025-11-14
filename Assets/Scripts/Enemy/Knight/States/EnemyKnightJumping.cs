using System;
using System.Collections;
using UnityEngine;

public class EnemyKnightJumping : EnemyKnightStateBase
{
    private Transform m_transform;

    public EnemyKnightJumping(EnemyKnightStateMachine pStateMachine, EnemyKnightBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
    }

    public override void Enter()
    {
        Jump();
    }

    private void Jump()
    {
        Vector3 targetPos = PlayerObject.transform.position;
        float distance = Vector3.Distance(targetPos, m_transform.position);
        if (distance > Info.MaxDistance)
        {
            Vector3 dir = (targetPos - m_transform.position).normalized;
            targetPos = m_transform.position + dir * Info.MaxDistance;
        }

        KnightBattle.StartCoroutine(JumpRoutine(targetPos));
    }

    private IEnumerator JumpRoutine(Vector3 pTargetPos)
    {
        yield return null;

        Vector3 startPos = m_transform.position;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / Info.JumpDuration;

            Vector3 pos = Vector3.Lerp(startPos, pTargetPos, t);

            float parabola = 4 * Info.JumpHeight * t * (1 - t);
            pos.y = parabola;

            m_transform.position = pos;

            yield return null;
        }

        m_transform.position = pTargetPos;
        yield return new WaitForSeconds(Info.AfterDelay);

        KnightStateMachine.ChangeState(KnightState.Chasing);
    }
}