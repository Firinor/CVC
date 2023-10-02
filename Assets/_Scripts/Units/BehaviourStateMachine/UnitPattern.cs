public class UnitPattern : UnitBehaviourStateMachine<UnitBehaviour<BasicUnit>, BasicUnit>
{
    public UnitPattern(UnitBehaviour<BasicUnit> startBehavior, BasicUnit unit) : base(startBehavior, unit)
    {
    }
}

public class WorkerPattern : UnitBehaviourStateMachine<UnitBehaviour<Worker>, Worker>
{
    public WorkerPattern(UnitBehaviour<Worker> startBehavior, Worker unit) : base(startBehavior, unit)
    {
    }
}