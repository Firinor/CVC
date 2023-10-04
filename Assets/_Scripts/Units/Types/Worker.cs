using FirUnityEditor;
using System;
using UnityEngine;
using Utility.UniRx;

public class Worker : BasicUnit
{
    [SerializeField]
    private IResourceCreator resourceCreator;
    [SerializeField, NullCheck]
    private WorkerPattern behavior;
    [SerializeField, NullCheck]
    private UnitBehaviour<Worker> startBehaviour;

    protected void FixedUpdate()
    {
        behavior.Tick();
    }


    public override void Initialize(Player player, UnitBasicStats stats)
    {
        base.Initialize(player, stats);

        behavior = new(startBehaviour, this);

        currentStats.Add(EUnitAttribute.WorkSpeed, new LimitedFloatReactiveProperty());
        InitWorkSpeed();
    }

    public void UnloadResources()
    {
        owner.GetResourcesFrom(inventory);
    }

    public void EnableExtract()
    {
        resourceCreator.EnableExtract();
    }
    public void DisableExtract()
    {
        resourceCreator.DisableExtract();
    }

    private void InitWorkSpeed()
    {
        var stat = currentStats[EUnitAttribute.WorkSpeed];
        stat.MinLimit = true;
        stat.MinValue = 0;
        stat.MaxLimit = false;
        stat.Value = basisStats.WorkSpeed;
    }
    public void FindNearestResources()
    {
        resourceCreator = owner.FindNearestResources();
        Target = resourceCreator;
    }
    public bool TryCompleteWork(float workTime)
    {
        float amountOfWork = currentStats[EUnitAttribute.WorkSpeed].Value * workTime;

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

    public void SetIdleBehavior()
    {
        behavior.SetIdleState();
    }
}
