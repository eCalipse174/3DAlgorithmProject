using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyKnightChasing : EnemyKnightStateBase
{
    private Transform m_transform;
    private float m_moveSpeed;
    private float m_attackDistance;
    private float m_jumpDistance;

    public EnemyKnightChasing(EnemyKnightStateMachine pStateMachine, float pMoveSpeed, float pAttackDistance, float pJumpDistance) : base(pStateMachine, null)
    {
        m_transform = pStateMachine.transform;
        m_moveSpeed = pMoveSpeed;
        m_attackDistance = pAttackDistance;
        m_jumpDistance = pJumpDistance;
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

            if (distance > m_jumpDistance)
            {
                KnightStateMachine.ChangeState(KnightState.Jumping);
            }
        }
        else
        {
            KnightStateMachine.ChangeState(KnightState.Attack);
        }
    }
}