using System;
using System.Collections;
using UnityEngine;

public class PlayerThirdAttack : PlayerStateBase
{
    public PlayerThirdAttack(PlayerStateMachine pStateMachine, BehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        m_waitingTime = 0;
        Attack();
    }

    public override void Update()
    {
        m_waitingTime += Time.deltaTime;

        if (Input.GetButtonDown("Dash"))
        {
            PlayerAnimator.StopPlayback();
            ChangeActions(PlayerState.Idle);

            PlayerStateMachine.ChangeState(PlayerState.Running);
        }

        if (m_waitingTime >= m_info.StopTime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                PlayerMovement.Jump();
            }

            if (m_waitingTime >= m_info.ComboWaitingTime)
                PlayerStateMachine.ChangeState(PlayerState.Idle);
        }
    }

    public override void Exit()
    {

    }

    protected override void Attack()
    {
        PlayerBattle.StartCoroutine(Do());
        //얍
        ChangeActions(PlayerState.ThirdAttack);
        // +앞으로가기;
        PlayerMovement.BehaviourMove(m_info.Distance, m_info.MovingCurve, m_info.StopTime);
    }

    protected override IEnumerator Do()
    {
        yield return null;

        yield return new WaitForSeconds(m_info.EffectDelay);
        PlayerEffects.PlayEffect(PlayerState.ThirdAttack);
        PlayerBattle.Hit(m_info, 0);

        yield return new WaitForSeconds(0.15f);
        PlayerBattle.Hit(m_info, 1);
    }
}