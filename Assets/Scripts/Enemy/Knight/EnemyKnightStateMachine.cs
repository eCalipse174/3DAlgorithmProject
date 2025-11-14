using System.Collections.Generic;
using UnityEngine;

public enum KnightState
{
    Chasing,
    Jumping,
    Attack
}

public class EnemyKnightStateMachine : StateControllerBase<KnightState>
{
    [SerializeField] private List<EnemyKnightBehaviourInfo> m_behaviourInfos = new List<EnemyKnightBehaviourInfo>();

    protected override Dictionary<KnightState, IState> CreateStates()
    {
        var stateByKey = new Dictionary<KnightState, IState>();

        stateByKey.Add(KnightState.Chasing, new EnemyKnightChasing(this, 7, 5, m_behaviourInfos[(int)KnightState.Jumping].JumpDistance));
        stateByKey.Add(KnightState.Jumping, new EnemyKnightJumping(this, m_behaviourInfos[(int)KnightState.Jumping]));
        stateByKey.Add(KnightState.Attack, new EnemyKnightAttack(this, m_behaviourInfos[(int)KnightState.Attack]));

        return stateByKey;
    }

    protected override KnightState GetInitialState()
    {
        return KnightState.Chasing;
    }
}
