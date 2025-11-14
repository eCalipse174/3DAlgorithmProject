using System;
using UnityEngine;

public class EnemyQueenIdle : EnemyQueenStateBase
{
    private Transform m_transform;
    private float m_IdleTime;
    private float m_chaseDistance;

    private float m_time;
    private float m_distance;

    public EnemyQueenIdle(EnemyQueenStateMachine pStateMachine, float pIdleTime, float pChaseDistance) : base(pStateMachine, null)
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
        m_distance = Vector3.Distance(m_transform.position, PlayerObject.transform.position);

        if (m_time > m_IdleTime)
        {
            QueenStateMachine.ChangeState(QueenState.Chasing);
        }
        if (m_distance > m_chaseDistance)
        {
            //QueenStateMachine.ChangeState(QueenState.RangeAttack);
        }
    }
}