using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class BattleBalance
{
    [Inject]
    private BattleBalanceScriptableObject battleBalance;
    [Inject]
    private StartBuildingScriptableObject startBuildingGrig;

    public IEnumerable<BuildingPosition> DefaultBuildings => startBuildingGrig.buildings;

    public float GetProductionRate(UnitClassEnum productionUnit)
    {
        return battleBalance.GetProductionRate(productionUnit);
    }

    public float GetProductionRate(ResourceEnum resource)
    {
        return battleBalance.GetProductionRate(resource);
    }

    public (float AmountOfWork, int ResourceCount) GetResourseCreatorData(ResourceEnum resource)
    {
        return battleBalance.GetResourseCreatorData(resource);
    }

    public UnitBasicStats GetStats(UnitClassEnum productionUnit)
    {
        return battleBalance.GetStats(productionUnit);
    }
}
