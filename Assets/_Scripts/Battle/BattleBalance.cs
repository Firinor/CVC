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

    public float GetProductionRate(UnitClass productionUnit)
    {
        return battleBalance.GetProductionRate(productionUnit);
    }

    public float GetProductionRate(Resource resource)
    {
        return battleBalance.GetProductionRate(resource);
    }

    public (float AmountOfWork, int ResourceCount) GetResourseCreatorData(Resource resource)
    {
        return battleBalance.GetResourseCreatorData(resource);
    }

    public UnitBasicStats GetStats(UnitClass productionUnit)
    {
        return battleBalance.GetStats(productionUnit);
    }
}
