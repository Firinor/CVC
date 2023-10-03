using UnityEngine;

public class UnitPattern : UnitBehaviourStateMachine<UnitBehaviour<BasicUnit>, BasicUnit>
{
    public UnitPattern(UnitBehaviour<BasicUnit> startBehavior, BasicUnit unit) : base(startBehavior, unit)
    {
    }
}

public class WorkerPattern : UnitBehaviourStateMachine<UnitBehaviour<Worker>, Worker>
{
    private UnitBehaviour<Worker> idle;

    public WorkerPattern(UnitBehaviour<Worker> startBehavior, Worker unit) : base(startBehavior, unit)
    {
        idle = ScriptableObject.CreateInstance<Idle>();
    }

    public void SetIdleState()
    {
        SetState(idle);
    }

    private class Idle : UnitBehaviour<Worker>
    {

    }
}