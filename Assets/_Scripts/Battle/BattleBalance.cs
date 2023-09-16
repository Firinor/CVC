using System;
using UnityEngine;

[Serializable]
public class BattleBalance
{
    [SerializeField]
    private BattleBalanceScriptableObject battleBalance;
    [SerializeField]
    private StartBuildingScriptableObject startBuildingGrig;

    private static BattleBalance instance;

    public BattleBalance(BattleBalanceScriptableObject battleBalance)
    {
        instance = this;
        this.battleBalance = battleBalance;
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
