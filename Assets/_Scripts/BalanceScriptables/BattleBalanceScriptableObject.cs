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

    internal float GetProductionRate(ResourceEnum resource)
    {
        switch (resource)
        {
            case ResourceEnum.Food:
                return Food.ProductionRate;
            case ResourceEnum.Mineral:
                return Mineral.ProductionRate;
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }

    public (float AmountOfWork, int ResourceCount) GetResourseCreatorData(ResourceEnum resource)
    {
        switch (resource)
        {
            case ResourceEnum.Food:
                return new(Food.AmountOfWork, Food.ResourceCount);
            case ResourceEnum.Mineral:
                return new(Mineral.AmountOfWork, Mineral.ResourceCount);
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }

    public float GetFarmWorkSpeed()
    {
        return Farm.WorkSpeed;
    }
    public float GetProductionRate(UnitClassEnum productionUnit)
    {
        switch (productionUnit)
        {
            case UnitClassEnum.Worker:
                return Worker.ProductionTime;
            case UnitClassEnum.Warrior:
                return Warrior.ProductionTime;
            case UnitClassEnum.Archer:
                return Archer.ProductionTime;
            case UnitClassEnum.Mage:
                return Mage.ProductionTime;
            case UnitClassEnum.Fly:
                return Fly.ProductionTime;
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }
    public UnitBasicStats GetStats(UnitClassEnum productionUnit)
    {
        switch (productionUnit)
        {
            case UnitClassEnum.Worker:
                return Worker.BasicStats;
            case UnitClassEnum.Warrior:
                return Warrior.BasicStats;
            case UnitClassEnum.Archer:
                return Archer.BasicStats;
            case UnitClassEnum.Mage:
                return Mage.BasicStats;
            case UnitClassEnum.Fly:
                return Fly.BasicStats;
            default:
                throw new Exception("It is impossible to get stats of a non-existent unit class!");
        }
    }
}
