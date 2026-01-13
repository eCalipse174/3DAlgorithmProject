using System.Collections;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private float m_knockbackDuration;
    private Rigidbody m_rigid;

    private void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
    }

    public void Knockback(float pForce, Transform pPlayer)
    {
        GameManager.Instance.StartCoroutine(KnockbackCoroutine(pForce, pPlayer));
    }

    private IEnumerator KnockbackCoroutine(float pForce, Transform pPlayer)
    {
        m_rigid.isKinematic = false;
        Vector3 dir = (transform.position - pPlayer.position).normalized;
        dir.y = 0;
        dir.Normalize();
        m_rigid.AddForce(dir * pForce, ForceMode.Impulse);

        yield return new WaitForSeconds(m_knockbackDuration);

        m_rigid.linearVelocity = Vector3.zero;
        m_rigid.isKinematic = true;
    }
}