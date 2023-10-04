using UnityEngine;

[CreateAssetMenu(menuName = "GameScriptable/UnitBehaviors/ExtractResourceBehavior")]
public class ExtractResource : UnitBehaviour<Worker>
{
    [Header("Behavior transitions")]
    [SerializeField]
    private UnitBehaviour<Worker> handOver;

    public override void Enter(Worker unit)
    {
        unit.ConnectToBuilding();
    }
    public override void Tick(Worker unit)
    {
        bool isCompleted = unit.TryCompleteWork(Time.fixedDeltaTime);
        if (isCompleted)
        {
            unit.SetBehavior(handOver);
            return;
        }
    }
    public override void Exit(Worker unit)
    {
        unit.DisconnectFromBuilding();
    }
}
