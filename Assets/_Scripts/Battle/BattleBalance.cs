using System;
using UnityEngine;

[Serializable]
public class BattleBalance
{
    [SerializeField]
    private BattleBalanceScriptableObject battleBalance;

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

    public static UnitBasisStats GetStats(UnitClass productionUnit)
    {
        return instance.battleBalance.GetStats(productionUnit);
    }
}
