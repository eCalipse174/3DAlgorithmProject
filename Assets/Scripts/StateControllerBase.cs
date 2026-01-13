using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateControllerBase<T> : MonoBehaviour
    where T : Enum
{
    private Dictionary<T, IState> m_stateByKey;
    private StateMachine m_stateMachine;

    private T m_currentState;
    public T CurrentState => m_currentState;

    protected GameObject m_playerObject;
    [HideInInspector] public GameObject PlayerObject => m_playerObject;

    private void Awake()
    {
        m_playerObject = GameObject.Find("Player");
        m_stateMachine = new StateMachine();
        m_stateByKey = CreateStates();
    }

    private void Start()
    {
        m_currentState = GetInitialState();
        m_stateMachine.ChangeState(m_stateByKey[m_currentState]);
    }

    private void Update()
    {
        m_stateMachine.Update();
    }

    public void ChangeState(T pState)
    {
        if (m_currentState.Equals(pState))
            return;

        m_currentState = pState;
        m_stateMachine.ChangeState(m_stateByKey[m_currentState]);
    }

    protected abstract Dictionary<T, IState> CreateStates();
    protected abstract T GetInitialState();
}