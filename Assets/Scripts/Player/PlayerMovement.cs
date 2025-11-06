using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_walkSpeed;
    [SerializeField] private float m_runSpeed;
    [SerializeField] private float m_jumpForce;

    [SerializeField] private LayerMask m_wallMask;

    [SerializeField] private Transform m_model;

    private readonly float m_jumpDelay = 0.2f;
    private readonly float m_dashDelay = 0.3f;
    private readonly float m_dashSpace = 0.2f;
    private readonly float m_landDelay = 0.5f;


    private float m_moveSpeed;
    public float MoveSpeed { get { return  m_moveSpeed; } }

    private float m_leftJumpDelay = 0;

    private float m_leftDashDelay = 0;
    private float m_dashSpaceDelay = 0;
    private float m_latestDirection = 0;

    private float m_leftLandDelay = 0;
    private bool m_isLanding = false;

    private bool m_isGrounded;
    private bool m_isAttacking;

    //private CharacterController m_characterController;
    private PlayerCamera m_playerCamera;
    private Animator m_animator;
    private Rigidbody m_rigidbody;

    private void Start()
    {
        m_playerCamera = GetComponent<PlayerCamera>();
        m_animator = GameObject.Find("KayinTest").GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_moveSpeed = m_walkSpeed;
        m_leftJumpDelay = m_jumpDelay;
        m_leftDashDelay = m_dashDelay;
        m_leftLandDelay = m_landDelay;
    }

    private void Update()
    {
        m_leftJumpDelay -= Time.deltaTime;
        m_leftDashDelay -= Time.deltaTime;
        m_dashSpaceDelay += Time.deltaTime;
        m_leftLandDelay -= Time.deltaTime;

        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (m_leftLandDelay <= 0)
            {
                StartCoroutine(Land());
            }
        }
    }

    private void FixedUpdate()
    {
        if (!m_isAttacking)
            {
                float horiz = Input.GetAxisRaw("Horizontal");
                float vert = Input.GetAxisRaw("Vertical");

                Vector3 input = new Vector3(horiz, 0, vert);

                if (input.sqrMagnitude > 0.01f)
                {
                    float cameraAngle = m_playerCamera.GetCameraAngle();
                    float angle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg + cameraAngle;

                    Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;

                    m_rigidbody.MovePosition(m_rigidbody.position + direction * m_moveSpeed * Time.fixedDeltaTime);

                    Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);
                    m_model.rotation = Quaternion.Slerp(m_model.rotation, targetRot, 0.15f);
            }
        }
    }

    private void Jump()
    {
        m_isGrounded = false;
        m_rigidbody.linearVelocity = Vector3.zero;
        m_rigidbody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);

        m_animator.SetTrigger("Jump");
    }

    //private IEnumerator DashCoroutine()
    //{
    //    Debug.Log("대시");
    //    m_leftDashDelay = m_dashDelay;

    //    m_rigidbody.AddForce();

    //    yield return new WaitForSeconds(0.1f);
    //    m_rigidbody.linearVelocity = Vector3.zero;
    //}

    //public void Dash()
    //{
    //    StartCoroutine(DashCoroutine());
    //}

    private IEnumerator Land()
    {
        m_isLanding = true;
        m_rigidbody.linearVelocity = Vector3.zero;
        //m_rigidbody.gravityScale = 0;

        //yield return new WaitForSeconds(0.1f);

        m_rigidbody.linearVelocity = Vector3.zero;
        m_rigidbody.AddForce(Vector3.down * m_jumpForce * 20);

        yield return new WaitForSeconds(0.1f);

        //m_rigidbody.gravityScale = 3;
        m_leftLandDelay = m_landDelay;
        m_isLanding = false;
    }

    /// <summary>
    /// 행동에서 얼마나 앞으로 가는지
    /// </summary>
    /// <param name="distance"></param>
    public void BehaviourMove(float pDistance, AnimationCurve pCurve, float pDuration)
    {
        StartCoroutine(BehaviourMoveCoroutine(pDistance, pCurve, pDuration));
    }

    private IEnumerator BehaviourMoveCoroutine(float pDistance, AnimationCurve pCurve, float pDuration)
    {
        float t = 0;
        Vector3 startPos = gameObject.transform.position;
        Vector3 moveDir = m_model.forward;

        while (t < pDuration)
        {
            float dist = pCurve.Evaluate(t / pDuration) * pDistance;
            transform.position = startPos + moveDir * dist;

            yield return null;
            t += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            m_isGrounded = true;
    }

    public void SetIsRunning(bool pIsRunning)
    {
        m_moveSpeed = pIsRunning ? m_runSpeed : m_walkSpeed;
    }

    public void SetIsAttacking(bool pIsAttacking)
    {
        m_isAttacking = pIsAttacking;
    }

}
