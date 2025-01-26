public abstract class BaseState
{
    public enemy enemy;
    public state_machine StateMachine;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}