using UnityEngine;

[CreateAssetMenu(menuName = "GameScriptable/UnitBehaviors/HandOverResources")]
public class HandOverResources : UnitBehaviour<Worker>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Worker> toResources;

    public override void Enter(Worker unit)
    {
        unit.FindNearestWarehouse();
    }

    public override void Tick(Worker unit)
    {
        if (unit.Target == null)
        {
            unit.SetIdleBehavior();
            return;
        }

        if (unit.IsNearTarget)
        {
            unit.UnloadResources();
            unit.SetBehavior(toResources);
            return;
        }

        unit.NavMeshAgent.SetDestination(unit.Target.Position);
    }
}
