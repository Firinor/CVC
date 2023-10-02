using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class HandOverResources : UnitBehaviour<BasicUnit>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<BasicUnit> toResources;

    public override void Enter(BasicUnit unit)
    {
        unit.FindNearestWarehouse();
    }

    public override void Tick(BasicUnit unit)
    {
        if (unit.IsNearTarget)
        {
            unit.SetBehavior(toResources);
            return;
        }

        unit.NavMeshAgent.SetDestination(unit.Target);
    }
}
