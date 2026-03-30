using UnityEngine;

public class EnemyRookCharge: EnemyRookStateBase
{
    private Transform m_transform;
    private float m_chargeTime;

    private float m_time;

    public EnemyRookCharge(EnemyRookStateMachine pStateMachine, float pChargeTime) : base(pStateMachine, null)
    {
        m_transform = pStateMachine.transform;
        m_chargeTime = pChargeTime;
    }

    public override void Enter()
    {
        m_time = 0;
        RookBattle.PlayEffect(0);
    }

    public override void Update()
    {
        m_time += Time.deltaTime;

        if (m_time > m_chargeTime)
        {
            RookStateMachine.ChangeState(RookState.Dash);
        }
    }
}