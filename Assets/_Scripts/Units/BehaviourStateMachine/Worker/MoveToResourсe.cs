using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class MoveToResourse : UnitBehaviour<BasicUnit>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<BasicUnit> toWork;

    public override void Enter(BasicUnit unit)
    {
        unit.FindNearestResources();
    }

    public override void Tick(BasicUnit unit)
    {
        if (unit.IsNearTarget)
        {
            unit.SetBehavior(toWork);
            return;
        }

        unit.NavMeshAgent.SetDestination(unit.Target);
    }
}
