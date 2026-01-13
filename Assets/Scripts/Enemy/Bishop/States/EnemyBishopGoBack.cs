using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBishopGoBack : EnemyBishopStateBase
{
    private Transform m_transform;

    public EnemyBishopGoBack(EnemyBishopStateMachine pStateMachine, EnemyBishopBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
    }

    public override void Enter()
    {
        GoBack();
    }

    private void GoBack()
    {
        var targetPos = PlayerObject.transform.position;

        Vector3 start = m_transform.position;
        Vector3 dir = (start - targetPos).normalized;

        Vector3 adjustedTarget = m_transform.position + Info.Distance * dir;
        adjustedTarget.y = 0;

        BishopBattle.StartCoroutine(MoveRoutine(adjustedTarget));

        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);
    }

    private IEnumerator MoveRoutine(Vector3 pTargetPos)
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

        BishopStateMachine.ChangeState(BishopState.Idle);
    }
}