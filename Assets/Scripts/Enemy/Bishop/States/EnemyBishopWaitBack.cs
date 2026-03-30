using UnityEngine;

public class EnemyBishopWaitBack : EnemyBishopStateBase
{
    private float m_waitTime;
    private float m_lateTime;

    public EnemyBishopWaitBack(EnemyBishopStateMachine pStateMachine, float pWaitTime) : base(pStateMachine, null)
    {
        m_waitTime = pWaitTime;
    }

    public override void Enter()
    {
        m_lateTime = 0;
    }

    public override void Update()
    {
        m_lateTime += Time.deltaTime;

        if (m_lateTime >= m_waitTime)
        {
            BishopStateMachine.ChangeState(BishopState.Idle);
        }
    }
}