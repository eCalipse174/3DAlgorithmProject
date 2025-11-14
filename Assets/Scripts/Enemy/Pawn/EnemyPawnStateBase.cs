using System;
using UnityEngine;

public class EnemyPawnStateBase : IState
{
    private EnemyPawnStateMachine m_pawnStateMachine;
    private GameObject m_playerObject;
    private EnemyPawnBehaviourInfo m_info;
    private EnemyPawnBattle m_pawnBattle;

    protected EnemyPawnStateMachine PawnStateMachine => m_pawnStateMachine;
    protected GameObject PlayerObject => m_playerObject;
    protected EnemyPawnBehaviourInfo Info => m_info;
    protected EnemyPawnBattle PawnBattle => m_pawnBattle;

    public EnemyPawnStateBase(EnemyPawnStateMachine pStateMachine, EnemyPawnBehaviourInfo pInfo)
    {
        m_pawnStateMachine = pStateMachine;
        m_pawnBattle = pStateMachine.GetComponent<EnemyPawnBattle>();
        m_playerObject = pStateMachine.PlayerObject;
        m_info = pInfo;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }
}