using System;
using UnityEngine;

public class PlayerRunning : PlayerStateBase
{
    public PlayerRunning(PlayerStateMachine pStateMachine, BehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(false);
        PlayerMovement.SetIsRunning(true);
        PlayerMovement.BehaviourStop();
        
        PlayerAnimator.SetBool(PlayerState.Walking.ToString(), true);
        PlayerAnimator.SetBool(PlayerState.Running.ToString(), true);
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerStateMachine.ChangeState(PlayerState.FirstSkill);
        }

        if (Input.GetButtonDown("Jump"))
        {
            PlayerMovement.Jump();
            PlayerStateMachine.ChangeState(PlayerState.Jumping);
        }
    }

    public override void Exit()
    {
        PlayerMovement.SetIsRunning(false);
        PlayerAnimator.SetBool(PlayerState.Running.ToString(), false);
    }
}