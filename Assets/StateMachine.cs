public delegate void StateCallback();

public abstract class StateBase
{
    public StateCallback Begin = () => {};
    public StateCallback End = () => {};
}

public class StateMachine<T> where T : StateBase
{
    T currentState;

    public StateMachine(T initialState)
    {
        currentState = initialState;
        currentState.Begin();
    }

    public void SetState(T state)
    {
        if (currentState.End != null) 
        {
            currentState.End();
        }

        currentState = state;

        if (currentState.Begin != null) 
        {
            currentState.Begin();
        }
    }

    public T GetState()
    {
        return currentState;
    }
}

