public class StateMachine
{
    public delegate void StateCallback();

    StateBase currentState;

    public void SetState(StateBase state)
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

    public StateBase GetState()
    {
        return currentState;
    }

    public abstract class StateBase
    {
        public StateCallback Begin;
        public StateCallback End;
    }
}
