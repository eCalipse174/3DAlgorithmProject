using UnityEngine;

public class EnemyHpBarScale : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private Canvas m_canvas;

    [Header("Scale")]
    [SerializeField] private float m_baseDistance = 10f;
    [SerializeField] private Vector3 m_baseScale;
    [SerializeField] private float m_minMultiplier = 0.5f;
    [SerializeField] private float m_maxMultiplier = 2f;

    [Header("Visibility")]
    [SerializeField] private float m_hideDistance = 30f;

    private Camera m_cam;

    private void Start()
    {
        m_cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (m_target == null)
            return;

        Vector3 camPos = m_cam.transform.position;
        Vector3 targetPos = m_target.position;

        float dist = (camPos - targetPos).magnitude;

        // Ç¥½Ã / ¼û±è
        if (m_canvas != null)
            m_canvas.enabled = dist <= m_hideDistance;

        if (dist > m_hideDistance)
            return;

        // À§Ä¡
        //transform.localPosition = targetPos;

        // ºôº¸µå
        transform.forward = m_cam.transform.forward;

        // ½ºÄÉÀÏ
        float multiplier = dist / m_baseDistance;
        multiplier = Mathf.Clamp(multiplier, m_minMultiplier, m_maxMultiplier);

        transform.localScale = m_baseScale * multiplier;
    }
}