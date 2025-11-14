using UnityEngine;

[CreateAssetMenu(fileName = "EnemyKnightBehaviourInfo", menuName = "Scriptable Objects/Enemy/EnemyKnightBehaviourInfo")]
public class EnemyKnightBehaviourInfo : EnemyBehaviourInfoBase<KnightState>
{
    [Space]
    [Header("Jump")]
    [SerializeField] private float jumpDistance;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float maxDistance;

    public float JumpDistance => jumpDistance;
    public float JumpHeight => jumpHeight;
    public float JumpDuration => jumpDuration;
    public float MaxDistance => maxDistance;
}