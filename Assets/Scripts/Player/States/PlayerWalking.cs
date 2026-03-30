using UnityEngine;

public class PlayerWalking : PlayerStateBase
{
    public PlayerWalking(PlayerStateMachine pStateMachine, BehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(false);
        //¾Ö´Ï¤Ä¤±ÀÌ¤Å¤¤¤µ
        PlayerAnimator.SetBool(PlayerState.Walking.ToString(), true);
    }

    public override void Update()
    {
        if (!(Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            PlayerStateMachine.ChangeState(PlayerState.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PlayerStateMachine.ChangeState(PlayerState.FirstAttack);

        if (Input.GetButton("Dash"))
        {
            //PlayerMovement.Dash();
            PlayerStateMachine.ChangeState(PlayerState.Running);
        }

        if (Input.GetKeyDown(KeyCode.E) &&
            PlayerBattle.SkillLateTime >= PlayerBattle.SkillCoolTime)
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
    }
}
