using System.Collections;
using UnityEngine;

public class PlayerStateBase : IState
{
    private PlayerStateMachine m_playerStateMachine;
    private PlayerMovement m_playerMovement;
    private PlayerCamera m_playerCamera;
    private PlayerBattle m_playerBattle;
    private PlayerEffects m_playerEffects;
    private Animator m_playerAnimator;

    protected PlayerStateMachine PlayerStateMachine => m_playerStateMachine;
    protected PlayerMovement PlayerMovement => m_playerMovement;
    protected PlayerCamera PlayerCamera => m_playerCamera;
    protected PlayerBattle PlayerBattle => m_playerBattle;
    protected PlayerEffects PlayerEffects => m_playerEffects;
    protected Animator PlayerAnimator => m_playerAnimator;

    /// <summary>
    /// 행동 정보
    /// </summary>
    protected BehaviourInfo m_info;
    /// <summary>
    /// 콤보 제한시간 경과 중
    /// </summary>
    protected float m_waitingTime;

    public PlayerStateBase(PlayerStateMachine pStateMachine, BehaviourInfo pInfo)
    {
        m_playerStateMachine = pStateMachine;
        m_playerMovement = pStateMachine.GetComponent<PlayerMovement>();
        m_playerCamera = pStateMachine.GetComponent<PlayerCamera>();
        m_playerBattle = pStateMachine.GetComponent<PlayerBattle>();
        m_playerEffects = pStateMachine.GetComponent<PlayerEffects>();

        m_playerAnimator = GameObject.Find("KayinTest").GetComponent<Animator>();
        m_info = pInfo;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }

    protected virtual void Attack() { }

    protected virtual IEnumerator Do()
    {
        yield return null;
    }

    protected void ChangeActions(PlayerState pNextState)
    {
        PlayerAnimator.StopPlayback();
        PlayerAnimator.Play(pNextState.ToString(), 0, 0);
        PlayerAnimator.Play(pNextState.ToString() + "_Weapon", 1, 0);
    }
}
