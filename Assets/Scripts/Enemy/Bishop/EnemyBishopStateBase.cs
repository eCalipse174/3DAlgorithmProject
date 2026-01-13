using UnityEngine;

public class EnemyBishopStateBase : IState
{
    private EnemyBishopStateMachine m_bishopStateMachine;
    private GameObject m_playerObject;
    private EnemyBishopBehaviourInfo m_info;
    private EnemyBishopBattle m_bishopBattle;

    protected EnemyBishopStateMachine BishopStateMachine => m_bishopStateMachine;
    protected GameObject PlayerObject => m_playerObject;
    protected EnemyBishopBehaviourInfo Info => m_info;
    protected EnemyBishopBattle BishopBattle => m_bishopBattle;

    public EnemyBishopStateBase(EnemyBishopStateMachine pStateMachine, EnemyBishopBehaviourInfo pInfo)
    {
        m_bishopStateMachine = pStateMachine;
        m_bishopBattle = pStateMachine.GetComponent<EnemyBishopBattle>();
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