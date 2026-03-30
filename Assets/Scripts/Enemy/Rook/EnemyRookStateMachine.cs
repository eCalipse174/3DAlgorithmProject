using System.Collections.Generic;
using UnityEngine;

public enum RookState
{
    Idle,
    Dash,
    Charge,
}

public class EnemyRookStateMachine : StateControllerBase<RookState>
{
    [SerializeField] private List<EnemyRookBehaviourInfo> m_behaviourInfos = new List<EnemyRookBehaviourInfo>(); 

    protected override Dictionary<RookState, IState> CreateStates()
    {
        var stateByKey = new Dictionary<RookState, IState>();

        stateByKey.Add(RookState.Idle, new EnemyRookIdle(this, 3.5f));
        stateByKey.Add(RookState.Dash, new EnemyRookDash(this, m_behaviourInfos[(int)RookState.Dash], -10));
        stateByKey.Add(RookState.Charge, new EnemyRookCharge(this, 0.5f));

        return stateByKey;
    }

    protected override RookState GetInitialState()
    {
        return RookState.Idle;
    }
}