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

        stateByKey.Add(QueenState.Idle, new EnemyQueenIdle(this, 1.7f, 20));
        stateByKey.Add(QueenState.Chasing, new EnemyQueenChasing(this, m_behaviourInfos[(int)QueenState.Chasing], 5, 1.7f));
        stateByKey.Add(QueenState.ComboAttack, new EnemyQueenComboAttack(this, m_behaviourInfos[(int)QueenState.ComboAttack]));
        stateByKey.Add(QueenState.RangeAttack, new EnemyQueenRangeAttack(this, m_behaviourInfos[(int)QueenState.RangeAttack]));
        stateByKey.Add(QueenState.BackStep, new EnemyQueenBackStep(this, m_behaviourInfos[(int)QueenState.BackStep]));

        return stateByKey;
    }

    protected override QueenState GetInitialState()
    {
        return QueenState.Idle;
    }
}
