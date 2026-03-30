public interface IState
{
    void Enter();
    void Update();
    void Exit();
}

public class StateMachine
{
    private IState m_currentState;

    public void ChangeState(IState pNewState)
    {
        if (PauseManager.Instance.IsPause)
            return;

        if (m_currentState != null)
            m_currentState.Exit();
        m_currentState = pNewState;
        m_currentState.Enter();
    }

    public void Update()
    {
        if (m_currentState != null)
            m_currentState.Update();
    }
}