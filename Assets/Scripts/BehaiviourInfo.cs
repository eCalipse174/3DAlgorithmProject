using UnityEngine;

[CreateAssetMenu(fileName = "BehaiviourInfo", menuName = "Scriptable Objects/BehaiviourInfo")]
public class BehaiviourInfo : ScriptableObject
{
    [SerializeField] private AnimationCurve movingCurve;
    [SerializeField] private float distance;

    [SerializeField] private float comboWaitingTime;
    [SerializeField] private float stopTime;

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
}
