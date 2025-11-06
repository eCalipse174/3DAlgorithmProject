using System.Collections;
using UnityEngine;

public class PlayerStateBase : IState
{
    private PlayerStateMachine m_playerStateMachine;
    private PlayerMovement m_playerMovement;
    private PlayerCamera m_playerCamera;
    private Animator m_playerAnimator;

    protected PlayerStateMachine PlayerStateMachine => m_playerStateMachine;
    protected PlayerMovement PlayerMovement => m_playerMovement;
    protected PlayerCamera PlayerCamera => m_playerCamera;
    protected Animator PlayerAnimator => m_playerAnimator;

    /// <summary>
    /// 행동 정보
    /// </summary>
    protected BehaiviourInfo m_info;
    /// <summary>
    /// 콤보 제한시간 경과 중
    /// </summary>
    protected float m_waitingTime;

    private TestVFX testVFX;
    protected TestVFX TestVFX => testVFX;

    public PlayerStateBase(PlayerStateMachine pStateMachine, BehaiviourInfo pInfo)
    {
        m_playerStateMachine = pStateMachine;
        m_playerMovement = pStateMachine.GetComponent<PlayerMovement>();
        m_playerCamera = pStateMachine.GetComponent<PlayerCamera>();

        m_playerAnimator = GameObject.Find("KayinTest").GetComponent<Animator>();
        m_info = pInfo;

        testVFX = pStateMachine.GetComponent<TestVFX>();
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }

    protected virtual void Attack()
    {

    }
}
