using System;
using System.Collections;
using UnityEngine;

public class PlayerFirstAttack : PlayerStateBase
{
    public PlayerFirstAttack(PlayerStateMachine pStateMachine, BehaviourInfo pInfo) : base(pStateMachine,  pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(true);
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerStateMachine.ChangeState(PlayerState.SecondAttack);
            }

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
        //¾å
        ChangeActions(PlayerState.FirstAttack);
        
        PlayerMovement.BehaviourMove(m_info.Distance, m_info.MovingCurve, m_info.StopTime);
    }

    protected override IEnumerator Do()
    {
        yield return null;

        yield return new WaitForSeconds(m_info.EffectDelay);
        PlayerEffects.PlayEffect(PlayerState.FirstAttack);
        PlayerBattle.Hit(m_info, 0);
    }
}