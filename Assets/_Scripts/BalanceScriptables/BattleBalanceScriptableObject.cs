using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleBalance", menuName = "GameBalance/BattleBalance")]
public class BattleBalanceScriptableObject : ScriptableObject
{
    public ResourceBattleBalanceStats Food;
    public ResourceBattleBalanceStats Mineral;

    public UnitBattleBalanceStats Worker;
    public UnitBattleBalanceStats Warrior;
    public UnitBattleBalanceStats Archer;
    public UnitBattleBalanceStats Mage;
    public UnitBattleBalanceStats Fly;

    public BuildingBattleBalanceStats Castle;
    public BuildingBattleBalanceStats Hous;
    public BuildingBattleBalanceStats Farm;
    public BuildingBattleBalanceStats Barrack;
    public BuildingBattleBalanceStats Tower;

    internal float GetProductionRate(Resource resource)
    {
        switch (resource)
        {
            case Resource.Food:
                return Food.ProductionRate;
            case Resource.Mineral:
                return Mineral.ProductionRate;
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }

    public (float AmountOfWork, int ResourceCount) GetResourseCreatorData(Resource resource)
    {
        switch (resource)
        {
            case Resource.Food:
                return new(Food.AmountOfWork, Food.ResourceCount);
            case Resource.Mineral:
                return new(Mineral.AmountOfWork, Mineral.ResourceCount);
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }

    public float GetFarmRate()
    {
        return Farm.ProductionRate;
    }
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
    public UnitBasicStats GetStats(UnitClass productionUnit)
    {
        switch (productionUnit)
        {
            case UnitClass.Worker:
                return Worker.BasicStats;
            case UnitClass.Warrior:
                return Warrior.BasicStats;
            case UnitClass.Archer:
                return Archer.BasicStats;
            case UnitClass.Mage:
                return Mage.BasicStats;
            case UnitClass.Fly:
                return Fly.BasicStats;
            default:
                throw new Exception("It is impossible to get stats of a non-existent unit class!");
        }
    }
}
