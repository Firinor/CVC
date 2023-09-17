using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleBalance
{
    [SerializeField]
    private BattleBalanceScriptableObject battleBalance;
    [SerializeField]
    private StartBuildingScriptableObject startBuildingGrig;

    private static BattleBalance instance;

    public IEnumerable<BuildingPosition> DefaultBuildings => startBuildingGrig.buildings;

    public void Initialize()
    {   
        instance = this;
    }

    public static float GetProductionRate(UnitClass productionUnit)
    {
        return instance.battleBalance.GetProductionRate(productionUnit);
    }

    public static float GetFarmRate()
    {
        return instance.battleBalance.GetFarmRate();
    }

    public static UnitBasisStats GetStats(UnitClass productionUnit)
    {
        return instance.battleBalance.GetStats(productionUnit);
    }
}
