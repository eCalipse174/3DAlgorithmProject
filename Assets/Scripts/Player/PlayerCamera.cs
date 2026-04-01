using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float m_cameraTopClamp;
    [SerializeField] private float m_cameraBottomClamp;
    [SerializeField] private GameObject m_followTarget;

    [Space]
    [Header("Cinemachine")]
    [SerializeField] private CinemachineThirdPersonFollow m_3rdPersonFollow;
    [SerializeField] private CinemachineImpulseSource m_impulseSource;

    private float m_mouseSensitivity = 1.0f;

    private float m_cameraTargetYaw;
    private float m_cameraTargetPitch;

    private float m_cameraDistance;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        m_cameraDistance = m_3rdPersonFollow.CameraDistance;
        m_mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
    }

    private void Update()
    {
        if (PauseManager.Instance != null &&
            PauseManager.Instance.IsPause)
            return;

        float mouseX = Input.GetAxisRaw("Mouse X") * m_mouseSensitivity * Time.deltaTime * 400f;
        float mouseY = -Input.GetAxisRaw("Mouse Y") * m_mouseSensitivity * Time.deltaTime * 400f;

        m_cameraTargetPitch += mouseY;
        m_cameraTargetYaw += mouseX;

        m_cameraTargetPitch = Mathf.Clamp(
            m_cameraTargetPitch,
            m_cameraBottomClamp,
            m_cameraTopClamp);

        m_followTarget.transform.rotation
            = Quaternion.Euler(
                m_cameraTargetPitch,
                m_cameraTargetYaw,
                0);

        //value min max 
    }

    public void Impulse()
    {
        m_impulseSource.GenerateImpulse();
    }

    public IEnumerator Shake(float pDuration, float pMagnitude)
    {
        Vector3 originPos = m_followTarget.transform.position;

        float elapsed = 0;

        while (elapsed < pDuration)
        {
            if (PauseManager.Instance.IsPause)
            {
                yield return null;
                continue;
            }

            float x = Random.Range(-1, 1) * pMagnitude;
            float y = Random.Range(-1, 1) * pMagnitude;

            m_followTarget.transform.position = new Vector3(originPos.x + x, originPos.y + y, originPos.z);
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        m_followTarget.transform.position = originPos;
    }

    public void ZoomCamera(AnimationCurve curve, float duration, float power)
    {
        StartCoroutine(Zoom(curve, duration, power));
    }

    private IEnumerator Zoom(AnimationCurve curve, float duration, float power)
    {
        float originDistance = m_cameraDistance;
        float elapsed = 0;

        while (elapsed < duration)
        {
            if (PauseManager.Instance.IsPause)
            {
                yield return null;
                continue;
            }

            float t = elapsed / duration;

            float value = curve.Evaluate(t);

            m_3rdPersonFollow.CameraDistance = originDistance + value * power;

            elapsed += Time.deltaTime;
            yield return null;
        }

        m_3rdPersonFollow.CameraDistance = originDistance;
    }

    public float GetCameraAngle()
        => m_followTarget.transform.eulerAngles.y;

    public void SetSensitivity(float value)
    {
        m_mouseSensitivity = value;
        PlayerPrefs.SetFloat("MouseSensitivity", value);
    }
}
