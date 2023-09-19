
using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class MoveToResourse : UnitBehaviour<Unit>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Unit> toWork;

    public override void Enter(Unit unit)
    {
        unit.FindNearestResources();
    }

    public override void Tick(Unit unit)
    {
        if (unit.IsNearTarget)
        {
            unit.SetBehavior(toWork);
            return;
        }

        unit.NavMeshAgent.SetDestination(unit.Target);
    }
}
