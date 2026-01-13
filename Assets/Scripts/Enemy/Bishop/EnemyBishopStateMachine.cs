using System.Collections.Generic;
using UnityEngine;

public enum BishopState
{
    Idle,
    Shot,
    GoBack,
}

public class EnemyBishopStateMachine : StateControllerBase<BishopState>
{
    [SerializeField] private List<EnemyBishopBehaviourInfo> m_behaviourInfos = new List<EnemyBishopBehaviourInfo>();

    protected override Dictionary<BishopState, IState> CreateStates()
    {
        var stateByKey = new Dictionary<BishopState, IState>();

        stateByKey.Add(BishopState.Idle, new EnemyBishopIdle(this, 3, 2));
        stateByKey.Add(BishopState.Shot, new EnemyBishopShot(this, m_behaviourInfos[(int)BishopState.Shot]));
        stateByKey.Add(BishopState.GoBack, new EnemyBishopGoBack(this, m_behaviourInfos[(int)BishopState.GoBack]));

        return stateByKey;
    }

    protected override BishopState GetInitialState()
    {
        return BishopState.Idle;
    }
}