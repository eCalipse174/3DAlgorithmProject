using System.Collections.Generic;
using UnityEngine;

public enum QueenState
{
    Idle,
    Chasing,
    ComboAttack,
    RangeAttack,
    BackStep
}

public class EnemyQueenStateMachine : StateControllerBase<QueenState>
{
    [SerializeField] private List<EnemyQueenBehaviourInfo> m_behaviourInfos = new List<EnemyQueenBehaviourInfo>();

    protected override Dictionary<QueenState, IState> CreateStates()
    {
        var stateByKey = new Dictionary<QueenState, IState>();

        stateByKey.Add(QueenState.Idle, new EnemyQueenIdle(this, 6, 20));
        stateByKey.Add(QueenState.Chasing, new EnemyQueenChasing(this, m_behaviourInfos[(int)QueenState.Chasing], 7));
        stateByKey.Add(QueenState.ComboAttack, new EnemyQueenComboAttack(this, m_behaviourInfos[(int)QueenState.ComboAttack]));

        return stateByKey;
    }

    protected override QueenState GetInitialState()
    {
        return QueenState.Idle;
    }
}
