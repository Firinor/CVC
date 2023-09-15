using System;
using UnityEngine;

public class BattleBalanceScriptableObject : ScriptableObject
{
    public UnitBattleBalanceStats Worker;
    public UnitBattleBalanceStats Warrior;
    public UnitBattleBalanceStats Archer;
    public UnitBattleBalanceStats Mage;
    public UnitBattleBalanceStats Fly;

    public float GetProductionRate(UnitClass productionUnit)
    {
        switch (productionUnit)
        {
            case UnitClass.Worker:
                return Worker.ProductionRate;
            case UnitClass.Warrior:
                return Warrior.ProductionRate;
            case UnitClass.Archer:
                return Archer.ProductionRate;
            case UnitClass.Mage:
                return Mage.ProductionRate;
            case UnitClass.Fly:
                return Fly.ProductionRate;
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }
}
