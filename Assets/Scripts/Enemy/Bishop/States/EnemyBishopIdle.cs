using UnityEngine;

public class EnemyBishopIdle : EnemyBishopStateBase
{
    private Transform m_transform;
    private float m_idleTime;
    private float m_goBackDistance;

    private float m_time;
    private float m_distance;

    public EnemyBishopIdle(EnemyBishopStateMachine pStateMachine, float pIdleTime, float pGoBackDistance) : base(pStateMachine, null)
    {
        m_transform = pStateMachine.transform;
        m_idleTime = pIdleTime;
        m_goBackDistance = pGoBackDistance;
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
        m_distance = Vector3.Distance(m_transform.position, PlayerObject.transform.position);

        if (m_time > m_idleTime)
        {
            BishopStateMachine.ChangeState(BishopState.Shot);
        }
        if (m_distance < m_goBackDistance)
        {
            BishopStateMachine.ChangeState(BishopState.GoBack);
        }
    }
}
