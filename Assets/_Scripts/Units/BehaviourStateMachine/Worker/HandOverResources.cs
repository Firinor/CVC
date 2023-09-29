using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class HandOverResources : UnitBehaviour<Unit>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Unit> toResources;

    public override void Enter(Unit unit)
    {
        unit.FindNearestWarehouse();
    }

    public override void Tick(Unit unit)
    {
        if (unit.IsNearTarget)
        {
            unit.SetBehavior(toResources);
            return;
        }

        unit.NavMeshAgent.SetDestination(unit.Target);
    }
}
