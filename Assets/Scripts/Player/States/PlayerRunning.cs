using System;
using UnityEngine;

public class PlayerRunning : PlayerStateBase
{
    public PlayerRunning(PlayerStateMachine pStateMachine, BehaiviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(false);
        //しいけしさ
        PlayerAnimator.SetBool(PlayerState.Running.ToString(), true);
        PlayerAnimator.Play(PlayerState.Running.ToString(), 0, 0);
    }

    public override void Update()
    {
        if (!(Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            PlayerStateMachine.ChangeState(PlayerState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayerStateMachine.ChangeState(PlayerState.FirstAttack);

        if (Input.GetButtonUp("Dash"))
        {
            PlayerStateMachine.ChangeState(PlayerState.Walking);
        }
    }

    public override void Exit()
    {
        PlayerMovement.SetIsRunning(false);
        PlayerAnimator.SetBool(PlayerState.Running.ToString(), false);
    }
}