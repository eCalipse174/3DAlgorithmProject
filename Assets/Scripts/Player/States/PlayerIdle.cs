using System;
using UnityEngine;

public class PlayerIdle : PlayerStateBase
{
    public PlayerIdle(PlayerStateMachine pStateMachine, BehaiviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerAnimator.SetBool(PlayerState.Walking.ToString(), false);
    }

    public override void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            PlayerStateMachine.ChangeState(PlayerState.Walking);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayerStateMachine.ChangeState(PlayerState.FirstAttack);
    }
}