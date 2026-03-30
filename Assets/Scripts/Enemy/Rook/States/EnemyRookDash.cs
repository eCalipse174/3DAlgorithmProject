using System.Collections;
using UnityEngine;

public class EnemyRookDash : EnemyRookStateBase
{
    private Transform m_transform;
    private float m_stopDistance;

    public EnemyRookDash(EnemyRookStateMachine pStateMachine, EnemyRookBehaviourInfo pInfo, float pStopDistance) : base(pStateMachine, pInfo)
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
        adjustedTarget.y = 0;

        RookBattle.StartCoroutine(ChaseRoutine(adjustedTarget));
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Rook);

        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);
    }

    private IEnumerator ChaseRoutine(Vector3 pTargetPos)
    {
        yield return null;

        Vector3 startPos = m_transform.position;
        float t = 0;

        bool isHit = false;

        while (t < 1)
        {
            t += Time.deltaTime / Info.Duration;
            float easedT = (t >= 1f) ? 1f : 1f - Mathf.Pow(2f, -10f * t);

            m_transform.position = Vector3.Lerp(startPos, pTargetPos, easedT);

            if (Vector3.Distance(
                m_transform.position, PlayerObject.transform.position
                )
                < Info.AreaRadius &&
                !isHit)
            {
                RookBattle.Hit(Info, 0);
                isHit = true;
            }

            yield return null;
        }

        m_transform.position = pTargetPos;

        RookStateMachine.ChangeState(RookState.Idle);
    }
}