using UnityEngine;

public class EnemyQueenStat : EnemyStat
{
    private EnemyQueenBattle m_battle;

    protected override void Start()
    {
        base.Start();

        m_battle = GetComponent<EnemyQueenBattle>();
    }

    public override void Hurt(float pDamage)
    {
        base.Hurt(pDamage);

        if (m_currentHp <= m_maxHp / 2)
        {
            m_battle.ChangePhase();
        }
    }
}