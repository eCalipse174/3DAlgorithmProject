using System;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Running,
    Jumping,

    FirstAttack,
    SecondAttack,
    ThirdAttack,

    FirstSkill
}

public class PlayerStateMachine : StateControllerBase<PlayerState>
{
    [SerializeField] private List<BehaviourInfo> m_behaviourInfos = new List<BehaviourInfo>();

    protected override Dictionary<PlayerState, IState> CreateStates()
    {
        var stateByKey = new Dictionary<PlayerState, IState>();

        stateByKey.Add(PlayerState.Idle, new PlayerIdle(this, null));
        stateByKey.Add(PlayerState.Walking, new PlayerWalking(this, null));
        stateByKey.Add(PlayerState.Running, new PlayerRunning(this, null));
        stateByKey.Add(PlayerState.Jumping, new PlayerJumping(this, null));
        stateByKey.Add(PlayerState.FirstAttack, new PlayerFirstAttack(this, m_behaviourInfos[(int)PlayerState.FirstAttack]));
        stateByKey.Add(PlayerState.SecondAttack, new PlayerSecondAttack(this, m_behaviourInfos[(int)PlayerState.SecondAttack]));
        stateByKey.Add(PlayerState.ThirdAttack, new PlayerThirdAttack(this, m_behaviourInfos[(int)PlayerState.ThirdAttack]));
        stateByKey.Add(PlayerState.FirstSkill, new PlayerFirstSkill(this, m_behaviourInfos[(int)PlayerState.FirstSkill]));

        return stateByKey;
    }

    protected override PlayerState GetInitialState()
    {
        return PlayerState.Idle;
    }
}