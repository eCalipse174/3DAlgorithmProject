using System;
using UnityEngine;

public class PlayerSecondAttack : PlayerStateBase
{
    public PlayerSecondAttack(PlayerStateMachine pStateMachine, BehaiviourInfo pInfo) : base(pStateMachine, pInfo)
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

        if (m_waitingTime >= m_info.StopTime)
        {
            if (Input.GetButtonDown("Dash"))
            {
                PlayerStateMachine.ChangeState(PlayerState.Running);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerStateMachine.ChangeState(PlayerState.ThirdAttack);
            }

            if (m_waitingTime >= m_info.ComboWaitingTime)
                PlayerStateMachine.ChangeState(PlayerState.Walking);
        }
    }

    public override void Exit()
    {

    }

    protected override void Attack()
    {
        //얍
        PlayerAnimator.Play(PlayerState.SecondAttack.ToString(), 0, 0);
        PlayerAnimator.Play(PlayerState.SecondAttack.ToString() + "_Weapon", 1, 0);
        // +앞으로가기;
        PlayerMovement.BehaviourMove(m_info.Distance, m_info.MovingCurve, m_info.StopTime);
    }
}