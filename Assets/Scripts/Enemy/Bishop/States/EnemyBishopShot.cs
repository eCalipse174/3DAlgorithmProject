using System.Collections;
using UnityEngine;

public class EnemyBishopShot : EnemyBishopStateBase
{
    private Transform m_transform;

    public EnemyBishopShot(EnemyBishopStateMachine pStateMachine, EnemyBishopBehaviourInfo pInfo) : base(pStateMachine, pInfo)
    {
        m_transform = pStateMachine.transform;
    }

    public override void Enter()
    {
        BishopBattle.StartCoroutine(Do());
    }

    private IEnumerator Do()
    {
        Vector3 targetPos = PlayerObject.transform.position;
        targetPos.y = m_transform.position.y;
        m_transform.LookAt(targetPos);

        BishopBattle.PlayEffect(0);
        BishopBattle.SetHitPosition(targetPos, Info.State);
        yield return new WaitForSeconds(Info.EffectDelay);
        BishopBattle.Hit(Info, 0);

        yield return new WaitForSeconds(Info.Duration);
        yield return new WaitForSeconds(Info.AfterDelay);
        BishopStateMachine.ChangeState(BishopState.Idle);
    }
}