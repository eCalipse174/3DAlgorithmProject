using System;
using System.Collections;
using UnityEngine;

public class PlayerFirstSkill : PlayerStateBase
{
    public PlayerFirstSkill(PlayerStateMachine pStateMachine, BehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
    }

    public override void Enter()
    {
        PlayerMovement.SetIsAttacking(true);
        PlayerAnimator.SetTrigger(PlayerState.FirstSkill.ToString());
        PlayerBattle.UseSkill();
        Attack();
    }

    public override void Exit()
    {
        PlayerMovement.SetIsAttacking(false);
    }

    protected override void Attack()
    {
        TargetingNearestEnemy();
        PlayerBattle.StartCoroutine(Do());
        //¾å
        ChangeActions(PlayerState.FirstSkill);

        PlayerMovement.BehaviourMove(m_info.Distance, m_info.MovingCurve, m_info.StopTime);
    }

    protected override IEnumerator Do()
    {
        yield return null;

        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Skill_A);
        PlayerCamera.ZoomCamera(m_info.CameraCurve, m_info.ZoomDuration, m_info.ZoomPower);

        yield return new WaitForSeconds(m_info.EffectDelay);
        PlayerBattle.StartCoroutine(PlayerCamera.Shake(0.4f, 0.3f));
        PlayerEffects.PlayEffect(PlayerState.FirstSkill);
        SoundManager.Instance.PlaySfx(SoundManager.Sfx.Skill_B);
        PlayerBattle.Hit(m_info, 0);

        yield return new WaitForSeconds(m_info.StopTime - m_info.EffectDelay);
        PlayerStateMachine.ChangeState(PlayerState.Idle);
    }
}