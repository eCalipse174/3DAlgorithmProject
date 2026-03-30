using UnityEngine;

public class EnemyRookIdle : EnemyRookStateBase
{
    private Transform m_transform;
    private float m_IdleTime;

    private float m_time;

    public EnemyRookIdle(EnemyRookStateMachine pStateMachine, float pIdleTime) : base(pStateMachine, null)
    {
        m_transform = pStateMachine.transform;
        m_IdleTime = pIdleTime;
    }

    public override void Enter()
    {
        m_time = 0;
    }

    public override void Update()
    {
        Vector3 targetPos = PlayerObject.transform.position;
        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);

        m_time += Time.deltaTime;

        if (m_time > m_IdleTime)
        {
            RookStateMachine.ChangeState(RookState.Charge);
        }
    }
}