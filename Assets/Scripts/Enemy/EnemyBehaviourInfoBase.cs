using System;
using System.Collections.Generic;
using UnityEngine;

public enum Enemy
{
    Pawn,
    Knight,
    Queen
}

public class EnemyBehaviourInfoBase<T> : ScriptableObject
    where T : Enum
{
    [SerializeField] protected Enemy m_enemy;
    [SerializeField] protected T m_state;

    [Space]
    [Header("Move")]

    [SerializeField] private AnimationCurve m_movingCurve;
    [SerializeField] private float distance;
    [SerializeField] private float duration;

    [Space]
    [Header("Hit")]

    [SerializeField] protected float areaRadius;
    [SerializeField] protected float effectDelay;
    [SerializeField] protected List<int> hits;

    [Space]
    [SerializeField] protected float afterDelay;


    public Enemy Enemy => m_enemy;
    public T State => m_state;

    public AnimationCurve MovingCurve => m_movingCurve;
    public float Distance => distance;
    public float Duration => duration;

    public float AreaRadius => areaRadius;
    public float EffectDelay => effectDelay;
    public List<int> Hits => hits;
    public float AfterDelay => afterDelay;
}
