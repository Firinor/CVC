using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class NewBehaviourScript : UnitBehaviour<Unit>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Unit> handOver;

    public override void Tick(Unit unit)
    {
        bool isCompleted = unit.TryCompleteWork(Time.fixedDeltaTime);
        if (isCompleted)
        {
            unit.SetBehavior(handOver);
            return;
        }
    }
}
