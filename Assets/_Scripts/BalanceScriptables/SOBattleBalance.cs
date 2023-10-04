using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleBalance", menuName = "GameBalance/BattleBalance")]
public class SOBattleBalance : ScriptableObject
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

    internal float GetProductionRate(EResource resource)
    {
        switch (resource)
        {
            case EResource.Food:
                return Food.ProductionRate;
            case EResource.Mineral:
                return Mineral.ProductionRate;
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }

    public (float AmountOfWork, int ResourceCount) GetResourseCreatorData(EResource resource)
    {
        switch (resource)
        {
            case EResource.Food:
                return new(Food.AmountOfWork, Food.ResourceCount);
            case EResource.Mineral:
                return new(Mineral.AmountOfWork, Mineral.ResourceCount);
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }

    public float GetFarmWorkSpeed()
    {
        return Farm.WorkSpeed;
    }
    public float GetProductionRate(EUnitClass productionUnit)
    {
        switch (productionUnit)
        {
            case EUnitClass.Worker:
                return Worker.ProductionTime;
            case EUnitClass.Warrior:
                return Warrior.ProductionTime;
            case EUnitClass.Archer:
                return Archer.ProductionTime;
            case EUnitClass.Mage:
                return Mage.ProductionTime;
            case EUnitClass.Fly:
                return Fly.ProductionTime;
            default:
                throw new Exception("It is impossible to get data of a non-existent unit class!");
        }
    }
    public UnitBasicStats GetStats(EUnitClass productionUnit)
    {
        switch (productionUnit)
        {
            case EUnitClass.Worker:
                return Worker.BasicStats;
            case EUnitClass.Warrior:
                return Warrior.BasicStats;
            case EUnitClass.Archer:
                return Archer.BasicStats;
            case EUnitClass.Mage:
                return Mage.BasicStats;
            case EUnitClass.Fly:
                return Fly.BasicStats;
            default:
                throw new Exception("It is impossible to get stats of a non-existent unit class!");
        }
    }
}
