using System;
using UniRx;
using UnityEngine;

public class ResourseCreator : Building, IResourceCreator
{
    [SerializeField]
    private float productionSpeed;
    public FloatReactiveProperty ProductionRate = new();
    public int resourceInWarehouse;
    [SerializeField]
    private Resource resource;
    private int resourceCount;
    private float amountOfWork;
    [SerializeField]
    private BuildingClass buildingClass;

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

    public ResourcePack GetResource()
    {
        if(resourceInWarehouse > 0)
        {
            resourceInWarehouse--;
            return new ResourcePack(resource, resourceCount);
        }

        throw new Exception("An attempt was made to get a non-existent resource!");
    }
}
