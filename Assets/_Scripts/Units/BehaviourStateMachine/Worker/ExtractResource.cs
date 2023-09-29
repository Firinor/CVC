using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class NewBehaviourScript : UnitBehaviour<Unit>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Unit> handOver;

    public override void Enter(Unit unit)
    {
        unit.SetAmountOfWork();
    }

    public override void Tick(Unit unit)
    {
        if (unit.IsWorkOver)
        {
            unit.SetBehavior(handOver);
            return;
        }

        unit.Work(Time.fixedDeltaTime);
    }
}
