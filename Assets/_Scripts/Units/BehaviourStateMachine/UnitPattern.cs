public class UnitPattern : UnitBehaviourStateMachine<UnitBehaviour<Unit>, Unit>
{
    public UnitPattern(UnitBehaviour<Unit> startBehavior, Unit unit) : base(startBehavior, unit)
    {
    }
}