using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyQueenComboAttack : EnemyQueenStateBase
{
    private Transform m_transform;

    public EnemyQueenComboAttack(EnemyQueenStateMachine pStateMachine, EnemyQueenBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
    }

    public override void Enter()
    {
        QueenBattle.StartCoroutine(Do());
    }

    private IEnumerator Do()
    {
        QueenBattle.PlayEffect((int)QueenAttack.Combo1);
        QueenBattle.StartCoroutine(Move(Info.Distance, Info.MovingCurve, Info.Duration));
        QueenBattle.Hit(Info, 0);
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.QueenSlash);
        yield return new WaitForSeconds(Info.EffectDelay); //여기서는 콤보 사이 딜레이

        QueenBattle.PlayEffect((int)QueenAttack.Combo2);
        QueenBattle.Hit(Info, 1);
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.QueenSlash);

        yield return new WaitForSeconds(Info.Duration - Info.EffectDelay);
        yield return new WaitForSeconds(Info.AfterDelay);
        QueenStateMachine.ChangeState(QueenState.Idle);
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