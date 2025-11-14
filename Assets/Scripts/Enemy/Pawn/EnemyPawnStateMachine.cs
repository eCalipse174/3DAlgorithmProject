using System.Collections.Generic;
using UnityEngine;

public enum PawnState
{
    Chasing,
    Attack
}

public class EnemyPawnStateMachine : StateControllerBase<PawnState>
{
    [SerializeField] private List<EnemyPawnBehaviourInfo> m_behaviourInfos = new List<EnemyPawnBehaviourInfo>();

    protected override Dictionary<PawnState, IState> CreateStates()
    {
        var stateByKey = new Dictionary<PawnState, IState>();

        stateByKey.Add(PawnState.Chasing, new EnemyPawnChasing(this, 3, 2));
        stateByKey.Add(PawnState.Attack, new EnemyPawnAttack(this, m_behaviourInfos[(int)PawnState.Attack]));

        return stateByKey;
    }

    protected override PawnState GetInitialState()
    {
        return PawnState.Chasing;
    }
}
