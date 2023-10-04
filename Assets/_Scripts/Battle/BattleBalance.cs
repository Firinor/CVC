using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class BattleBalance
{
    [Inject]
    private SOBattleBalance battleBalance;
    [Inject]
    private SOStartBuilding startBuildingGrig;

    public IEnumerable<BuildingPosition> DefaultBuildings => startBuildingGrig.buildings;

    public float GetProductionRate(EUnitClass productionUnit)
    {
        return battleBalance.GetProductionRate(productionUnit);
    }

    public float GetProductionRate(EResource resource)
    {
        return battleBalance.GetProductionRate(resource);
    }

    public (float AmountOfWork, int ResourceCount) GetResourseCreatorData(EResource resource)
    {
        return battleBalance.GetResourseCreatorData(resource);
    }

    public UnitBasicStats GetStats(EUnitClass productionUnit)
    {
        return battleBalance.GetStats(productionUnit);
    }
}
