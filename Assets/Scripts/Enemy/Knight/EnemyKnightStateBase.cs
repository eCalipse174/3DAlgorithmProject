using System;
using UnityEngine;

public class EnemyKnightStateBase : IState
{
    private EnemyKnightStateMachine m_knightStateMachine;
    private GameObject m_playerObject;
    private EnemyKnightBehaviourInfo m_info;
    private EnemyKnightBattle m_knightBattle;

    protected EnemyKnightStateMachine KnightStateMachine => m_knightStateMachine;
    protected GameObject PlayerObject => m_playerObject;
    protected EnemyKnightBehaviourInfo Info => m_info;
    protected EnemyKnightBattle KnightBattle => m_knightBattle;

    public EnemyKnightStateBase(EnemyKnightStateMachine pStateMachine, EnemyKnightBehaviourInfo pInfo)
    {
        m_knightStateMachine = pStateMachine;
        m_knightBattle = pStateMachine.GetComponent<EnemyKnightBattle>();
        m_playerObject = pStateMachine.PlayerObject;
        m_info = pInfo;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }
}