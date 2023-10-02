using UnityEngine;
using Utility.UniRx;

public class Worker : BasicUnit
{
    [SerializeField]
    private IResourceCreator resourceCreator;
    private WorkerPattern behavior;

    public override void Initialize(Player player, UnitBasicStats stats, UnitBehaviour<BasicUnit> startBehaviour)
    {
        base.Initialize(player, stats, startBehaviour);
        currentStats.Add(UnitAttributeEnum.WorkSpeed, new LimitedFloatReactiveProperty());
        InitWorkSpeed();
    }
    private void InitWorkSpeed()
    {
        var stat = currentStats[UnitAttributeEnum.WorkSpeed];
        stat.MinLimit = true;
        stat.MinValue = 0;
        stat.MaxLimit = false;
        stat.Value = basisStats.WorkSpeed;
    }
    public void FindNearestResources()
    {
        targets[1] = owner.FindNearestResources();
    }
    public bool TryCompleteWork(float workTime)
    {
        float amountOfWork = currentStats[UnitAttributeEnum.WorkSpeed].Value * workTime;

        if (resourceCreator.TryCompleteWork(amountOfWork))
        {
            inventory.Add(resourceCreator.GetResource());
            return true;
        }

        return false;
    }

    public void SetBehavior(UnitBehaviour<Worker> newBehavior)
    {
        behavior.SetState(newBehavior);
    }
}
