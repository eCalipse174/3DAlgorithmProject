using System;
using UnityEngine;

public class PlayerJumping : PlayerStateBase
{
    public PlayerJumping(PlayerStateMachine pStateMachine, BehaiviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerAnimator.SetTrigger("Jump");
        if (Input.GetButton("Dash"))
            PlayerAnimator.SetBool(PlayerState.Running.ToString(), true);
    }

    public override void Update()
    {
        if (Input.GetButtonUp("Dash"))
            PlayerAnimator.SetBool(PlayerState.Running.ToString(), false);

        if (PlayerMovement.IsGrounded)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                if (Input.GetButton("Dash"))
                    PlayerStateMachine.ChangeState(PlayerState.Running);
                else
                    PlayerStateMachine.ChangeState(PlayerState.Walking);
            }
            else
                PlayerStateMachine.ChangeState(PlayerState.Idle);
        }
    }
}