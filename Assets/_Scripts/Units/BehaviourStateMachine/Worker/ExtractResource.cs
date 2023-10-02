using UnityEngine;

[CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/WorkerMove")]
public class NewBehaviourScript : UnitBehaviour<Worker>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Worker> handOver;

    public override void Tick(Worker unit)
    {
        bool isCompleted = unit.TryCompleteWork(Time.fixedDeltaTime);
        if (isCompleted)
        {
            unit.SetBehavior(handOver);
            return;
        }
    }
}
