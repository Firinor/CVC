using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class MoveToResource : UnitBehaviour<Worker>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Worker> toWork;

    public override void Enter(Worker unit)
    {
        unit.FindNearestResources();
    }

    public override void Tick(Worker unit)
    {
        if(unit.Target == null)
        {
            unit.SetIdleBehavior();
            return;
        }

        if (unit.IsNearTarget)
        {
            unit.SetBehavior(toWork);
            return;
        }

        unit.NavMeshAgent.SetDestination(unit.Target.Position);
    }
}
