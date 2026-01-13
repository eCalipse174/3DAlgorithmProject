using UnityEngine;

public class EnemyRookStateBase : IState
{
    private EnemyRookStateMachine m_RookStateMachine;
    private GameObject m_playerObject;
    private EnemyRookBehaviourInfo m_info;
    private EnemyRookBattle m_RookBattle;

    protected EnemyRookStateMachine RookStateMachine => m_RookStateMachine;
    protected GameObject PlayerObject => m_playerObject;
    protected EnemyRookBehaviourInfo Info => m_info;
    protected EnemyRookBattle RookBattle => m_RookBattle;

    public EnemyRookStateBase(EnemyRookStateMachine pStateMachine, EnemyRookBehaviourInfo pInfo)
    {
        m_RookStateMachine = pStateMachine;
        m_RookBattle = pStateMachine.GetComponent<EnemyRookBattle>();
        m_playerObject = pStateMachine.PlayerObject;
        m_info = pInfo;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }
}