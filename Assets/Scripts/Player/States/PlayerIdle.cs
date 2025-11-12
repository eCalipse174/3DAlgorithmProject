using System;
using UnityEngine;

public class PlayerIdle : PlayerStateBase
{
    public PlayerIdle(PlayerStateMachine pStateMachine, BehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(false);
        PlayerAnimator.SetBool(PlayerState.Walking.ToString(), false);
    }

    public override void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            PlayerStateMachine.ChangeState(PlayerState.Walking);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayerStateMachine.ChangeState(PlayerState.FirstAttack);

        if (Input.GetButtonDown("Jump"))
        {
            PlayerMovement.Jump();
            PlayerStateMachine.ChangeState(PlayerState.Jumping);
        }
    }
}