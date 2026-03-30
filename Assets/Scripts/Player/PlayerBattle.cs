using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour, ICoroutineHost
{
    private Dictionary<PlayerState, Transform> m_hitTransforms;

    [SerializeField] private float m_skillCooltime = 3f;
    private float m_skillLateTime;
    public float SkillCoolTime => m_skillCooltime;
    public float SkillLateTime => m_skillLateTime; 

    private void Start()
    {
        m_hitTransforms = new Dictionary<PlayerState, Transform>();
        m_hitTransforms.Add(PlayerState.FirstAttack, GameObject.Find(PlayerState.FirstAttack.ToString() + "Transform").transform);
        m_hitTransforms.Add(PlayerState.SecondAttack, GameObject.Find(PlayerState.SecondAttack.ToString() + "Transform").transform);
        m_hitTransforms.Add(PlayerState.ThirdAttack, GameObject.Find(PlayerState.ThirdAttack.ToString() + "Transform").transform);

        m_hitTransforms.Add(PlayerState.FirstSkill, GameObject.Find(PlayerState.FirstSkill.ToString() + "Transform").transform);

        m_skillLateTime = m_skillCooltime;
    }

    private void Update()
    {
        m_skillLateTime += Time.deltaTime;
        UIManager.Instance.ShowSkillCooltime(m_skillLateTime / 3);
    }

    public void UseSkill()
    {
        m_skillLateTime = 0;
    }

    public void Hit(BehaviourInfo pInfo, int pHitIndex)
    {
        Collider[] hits;
        Transform trans = m_hitTransforms[pInfo.State];

        hits = Physics.OverlapSphere(trans.position, pInfo.AreaRadius);
        foreach (var hit in hits)
        {
            // 에너미 때리기
            if (hit.CompareTag("Enemy"))
            {
                //Debug.Log($"{name}이(가) {hit.name}에게 {pInfo.Hits[pHitIndex]} 데미지!");
                hit.GetComponent<EnemyStat>().Hurt(pInfo.Hits[pHitIndex]);
                HitStopManager.Instance.Stop(pInfo.HitStopDuration);
                if (hit.TryGetComponent<EnemyKnockback>(out var knockback))
                {
                    knockback.Knockback(pInfo.KnockbackForce, transform);
                }
            }
        }
    }
}
