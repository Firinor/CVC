using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ResourseCreator : Building, IResourceCreator
{
    [SerializeField]
    private float productionSpeed;
    public FloatReactiveProperty ProductionRate = new();

    public BoolReactiveProperty IsEnable = new(false);
    public int resourceInWarehouse;
    [SerializeField]
    private EResource resource;
    private int resourceCount;
    private float amountOfWork;
    [SerializeField]
    private EBuilding buildingClass;
    private List<Worker> workers = new();

    public float WorkRequired => battleBalance.GetProductionRate(resource);

    private void Start()
    {
        owner.AddBuilding(buildingClass, this);
        var InitValues = battleBalance.GetResourseCreatorData(resource);
        amountOfWork = InitValues.AmountOfWork;
        resourceCount = InitValues.ResourceCount;
    }

    public bool TryCompleteWork(float workAmount)
    {
        if (ProductionRate.Value <= 0 && resourceInWarehouse <= 0)
        {
            ProductionRate.Value += amountOfWork;
        }

        if (ProductionRate.Value > 0)
        {
            ProductionRate.Value -= workAmount;
            if (ProductionRate.Value <= 0)
            {
                resourceInWarehouse++;
                return true;
            }
        }

        return false;
    }

    public ResourceAmount GetResource()
    {
        if(resourceInWarehouse > 0)
        {
            resourceInWarehouse--;
            return new ResourceAmount(resource, resourceCount);
        }

        throw new Exception("An attempt was made to get a non-existent resource!");
    }

    public void ConnectToBuilding(Worker worker)
    {
        workers.Add(worker);

        if (workers.Count > 1)
            worker.IsSleep = true;

        IsEnable.Value = true;
    }

    public void DisconnectFromBuilding(Worker worker)
    {
        workers.Remove(worker);

        if (workers.Count > 0)
            workers[0].IsSleep = false;

        IsEnable.Value = workers.Count > 0;
    }
}
