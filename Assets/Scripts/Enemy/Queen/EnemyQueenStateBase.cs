using System;
using UnityEngine;

public class EnemyQueenStateBase : IState
{
    private EnemyQueenStateMachine m_queenStateMachine;
    private GameObject m_playerObject;
    private EnemyQueenBehaviourInfo m_info;
    private EnemyQueenBattle m_queenBattle;

    protected EnemyQueenStateMachine QueenStateMachine => m_queenStateMachine;
    protected GameObject PlayerObject => m_playerObject;
    protected EnemyQueenBehaviourInfo Info => m_info;
    protected EnemyQueenBattle QueenBattle => m_queenBattle;

    public EnemyQueenStateBase(EnemyQueenStateMachine pStateMachine, EnemyQueenBehaviourInfo pInfo)
    {
        m_queenStateMachine = pStateMachine;
        m_queenBattle = pStateMachine.GetComponent<EnemyQueenBattle>();
        m_playerObject = pStateMachine.PlayerObject;
        m_info = pInfo;
    }
    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }
}