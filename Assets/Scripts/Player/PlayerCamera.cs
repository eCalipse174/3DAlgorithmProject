using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float m_cameraTopClamp;
    [SerializeField] private float m_cameraBottomClamp;
    [SerializeField] private GameObject m_followTarget;

    private float m_cameraTargetYaw;
    private float m_cameraTargetPitch;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = -Input.GetAxisRaw("Mouse Y");

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

    public float GetCameraAngle()
        => m_followTarget.transform.eulerAngles.y;
}
