using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BehaviourInfo", menuName = "Scriptable Objects/BehaviourInfo")]
public class BehaviourInfo : ScriptableObject
{
    [SerializeField] private PlayerState m_state;

    [Space]
    [Header("Character Move")]

    [SerializeField] private AnimationCurve movingCurve;
    [SerializeField] private float distance;

    [SerializeField] private float comboWaitingTime;
    [SerializeField] private float stopTime;

    [Space]
    [Header("Camera")]

    [SerializeField] private AnimationCurve cameraCurve;
    [SerializeField] private float zoomDuration;
    [SerializeField] private float zoomPower;


    [Space]
    [Header("Hit")]

    [SerializeField] private float areaRadius;
    [SerializeField] private float effectDelay;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float hitStopDuration;
    [SerializeField] private List<int> hits;


    public PlayerState State => m_state;

    public AnimationCurve MovingCurve => movingCurve;
    /// <summary>
    /// 동작 이동 거리
    /// </summary>
    public float Distance => distance;
    /// <summary>
    /// 콤보 제한시간
    /// </summary>
    public float ComboWaitingTime => comboWaitingTime;
    /// <summary>
    /// 공격 경직 (동작 진행 시간, 이 기간 동안은 콤보 진행 불가능)
    /// </summary>
    public float StopTime => stopTime;

    public AnimationCurve CameraCurve => cameraCurve;
    public float ZoomDuration => zoomDuration;
    public float ZoomPower => zoomPower;

    public float AreaRadius => areaRadius;
    public float EffectDelay => effectDelay;
    public float HitStopDuration => hitStopDuration;
    public float KnockbackForce => knockbackForce;
    public List<int> Hits => hits;
}
