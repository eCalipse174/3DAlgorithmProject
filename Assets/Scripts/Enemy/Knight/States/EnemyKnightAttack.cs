using System;
using System.Collections;
using UnityEngine;

public class EnemyKnightAttack : EnemyKnightStateBase
{
    private Transform m_transform;

    public EnemyKnightAttack(EnemyKnightStateMachine pStateMachine, EnemyKnightBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
    }

    public override void Enter()
    {
        KnightBattle.StartCoroutine(Do());
    }

    private IEnumerator Do()
    {
        Vector3 targetPos = PlayerObject.transform.position;
        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);

        KnightBattle.PlayEffect(0);
        yield return new WaitForSeconds(Info.EffectDelay);
        KnightBattle.StartCoroutine(Move(Info.Distance, Info.MovingCurve, Info.Duration));
        KnightBattle.Hit(Info, 0);

        yield return new WaitForSeconds(Info.Duration);
        yield return new WaitForSeconds(Info.AfterDelay);
        KnightStateMachine.ChangeState(KnightState.Chasing);
    }

    private IEnumerator Move(float pDistance, AnimationCurve pCurve, float pDuration)
    {
        float t = 0;
        Vector3 startPos = m_transform.position;
        Vector3 moveDir = m_transform.forward;

        while (t < pDuration)
        {
            float dist = pCurve.Evaluate(t / pDuration) * pDistance;
            m_transform.position = startPos + moveDir * dist;

            yield return null;
            t += Time.deltaTime;
        }
    }
}