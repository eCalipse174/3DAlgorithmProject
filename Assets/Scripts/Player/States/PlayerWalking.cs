using UnityEngine;

public class PlayerWalking : PlayerStateBase
{
    public PlayerWalking(PlayerStateMachine pStateMachine, BehaiviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(false);
        //¾Ö´Ï¤Ä¤±ÀÌ¤Å¤¤¤µ
        PlayerAnimator.SetBool(PlayerState.Walking.ToString(), true);
        PlayerAnimator.Play(PlayerState.Walking.ToString(), 0, 0);
    }

    public override void Update()
    {
        if (!(Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            PlayerStateMachine.ChangeState(PlayerState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayerStateMachine.ChangeState(PlayerState.FirstAttack);

        if (Input.GetButtonDown("Dash"))
        {
            //PlayerMovement.Dash();
            PlayerMovement.SetIsRunning(true);
            PlayerStateMachine.ChangeState(PlayerState.Running);
        }
    }

    public override void Exit()
    {
    }
}
