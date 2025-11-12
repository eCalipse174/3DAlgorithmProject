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

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private List<BehaviourInfo> m_behaiviourInfos = new List<BehaviourInfo>();

    private StateMachine m_stateMachine;
    private Dictionary<PlayerState, IState> m_stateByKey;

    private PlayerState m_currentState;
    public PlayerState CurrentState { get { return m_currentState; } }

    private void Awake()
    {
        m_stateMachine = new StateMachine();
        m_stateByKey = new Dictionary<PlayerState, IState>();
        m_stateByKey.Add(PlayerState.Idle, new PlayerIdle(this, null));
        m_stateByKey.Add(PlayerState.Walking, new PlayerWalking(this, null));
        m_stateByKey.Add(PlayerState.Running, new PlayerRunning(this, null));
        m_stateByKey.Add(PlayerState.Jumping, new PlayerJumping(this, null));
        m_stateByKey.Add(PlayerState.FirstAttack, new PlayerFirstAttack(this, m_behaiviourInfos[(int)PlayerState.FirstAttack]));
        m_stateByKey.Add(PlayerState.SecondAttack, new PlayerSecondAttack(this, m_behaiviourInfos[(int)PlayerState.SecondAttack]));
        m_stateByKey.Add(PlayerState.ThirdAttack, new PlayerThirdAttack(this, m_behaiviourInfos[(int)PlayerState.ThirdAttack]));
        m_stateByKey.Add(PlayerState.FirstSkill, new PlayerFirstSkill(this, m_behaiviourInfos[(int)PlayerState.FirstSkill]));
    }

    private void Start()
    {
        m_currentState = PlayerState.Walking;
        m_stateMachine.ChangeState(m_stateByKey[PlayerState.Walking]);
    }

    private void Update()
    {
        m_stateMachine.Update();
    }

    public void ChangeState(PlayerState pState)
    {
        if (pState == CurrentState)
            return;

        //Debug.Log($"State Changed: {m_currentState} => {pState}");
        m_currentState = pState;
        m_stateMachine.ChangeState(m_stateByKey[m_currentState]);
    }
}