using System;
using UnityEngine;

public class EnemyPawnChasing : EnemyPawnStateBase
{
    private Transform m_transform;
    private float m_moveSpeed;
    private float m_attackDistance;

    public EnemyPawnChasing(EnemyPawnStateMachine pStateMachine, float pMoveSpeed, float pAttackDistance) : base(pStateMachine, null)
    {
        m_transform = pStateMachine.transform;
        m_moveSpeed = pMoveSpeed;
        m_attackDistance = pAttackDistance;
    }

    public override void Update()
    {
        Vector3 targetPos = PlayerObject.transform.position;
        targetPos.y = m_transform.position.y;

        float distance = Vector3.Distance(targetPos, m_transform.position);

        if (distance > m_attackDistance)
        {
            m_transform.LookAt(targetPos);
            m_transform.position += m_transform.forward * m_moveSpeed * Time.deltaTime;
        }
        else
        {
            PawnStateMachine.ChangeState(PawnState.Attack);
        }

        
    }
}