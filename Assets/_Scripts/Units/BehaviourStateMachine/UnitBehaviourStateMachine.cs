public class UnitBehaviourStateMachine<TBehaviour, TUnit> where TBehaviour : UnitBehaviour<TUnit> where TUnit : Unit
{ 
    public TBehaviour currentBehaviour { get; protected set; }
    protected TUnit unit;

    public UnitBehaviourStateMachine(TBehaviour startBehavior, TUnit unit)
    {
        currentBehaviour = startBehavior;
        this.unit = unit;
        currentBehaviour.Enter(unit);
    }

    public virtual void SetState(TBehaviour newBehavior)
    {
        currentBehaviour.Exit(unit);
        currentBehaviour = newBehavior;
        currentBehaviour.Enter(unit);
    }

    public virtual void Tick()
    {
        currentBehaviour.Tick(unit);
    }
}
