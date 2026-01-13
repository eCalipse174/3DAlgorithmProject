using UnityEngine;

public class EnemyBishopBattle : EnemyBattleBase<BishopState>
{
    private void Start()
    {
        m_hitTransforms = new();
        m_effects = new();
        m_hitTransforms.Add(BishopState.Shot, transform.Find("AttackTransform"));
        m_effects.Add(transform.Find("AttackEffect").GetComponent<UnityEngine.VFX.VisualEffect>());

        m_hitEffect = transform.Find("HitEffect").GetComponent<UnityEngine.VFX.VisualEffect>();
    }

    public void SetHitPosition(Vector3 pPos, BishopState pState)
    {
        m_hitTransforms[pState].position = pPos;
    }
}