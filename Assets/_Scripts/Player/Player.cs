using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class Player
{
    private Resourses resourses = new();
    private Buildings buildings = new Buildings();
    private Units units = new Units();
    private Tactic taktics = new Tactic();
    private Dictionary<BasicUnit, Building> unitWork = new();

    public bool IsAlive => buildings.Castle.IsAlive;

    public Vector3 CastlePosition => buildings.Castle.transform.position;

    #region Taktics
    public (int, bool) NeedUnit(int step, EUnitClass unitClass, EResource resource)
    {
        throw new Exception("TODO!");
    }
    #endregion
    #region Resourses
    public IntReactiveProperty this[EResource key] => resourses[key];

    private class Resourses
    {
        public IntReactiveProperty Food = new();
        public IntReactiveProperty Mineral = new();

        public IntReactiveProperty this[EResource key] => key == EResource.Food ? Food : Mineral;

        public void AddResource(ResourceAmount resource)
        {
            switch (resource.Resource)
            {
                case EResource.Food:
                    Food.Value += resource.Count;
                    break;
                case EResource.Mineral:
                    Mineral.Value += resource.Count;
                    break;
                default:
                    throw new Exception($"The player is trying to get an unknown type of resource: {resource.Resource}!");
            }
        }
    }
    public IResourceCreator FindNearestResources()
    {
        var result = from farm in buildings.Farms
                     orderby farm.Distance()
                     orderby !farm.IsEnable.Value
                     select farm;

        if (result.Any())
        {
            Building resultFarm = result.First();

            return (IResourceCreator)resultFarm;
        }

        return null;
    }

    public void GetResourcesFrom(List<IItem> inventory)
    {
        for (int i = 0; i < inventory.Count;)
        {
            if(inventory[i] is ResourceAmount resource)
            {
                resourses.AddResource(resource);
                inventory.RemoveAt(i);
                continue;
            }
            i++;
        }
    }

    public ITarget FindNearestWarehouse(Vector3 position)
    {
        return buildings.Castle;
    }
    #endregion
    #region Buildings
    private class Buildings
    {
        public UnitCreator Castle;
        public List<ResourseCreator> Farms = new();
        public List<UnitCreator> Barracks = new();
        public List<Building> Towers = new();
        public List<UnitCreator> Houses = new();
    }

    public bool IsNeedMoreUnits(EUnitClass unitClass)
    {
        switch (unitClass)
        {
            case EUnitClass.Worker:
                return units.Workers.Count < taktics.WorkersLimit;
            case EUnitClass.Warrior:
                return units.Warriors.Count < taktics.WarriorsLimit;
            default:
                break;
        }

        return false;
    }

    public void AddBuilding(EBuilding buildingClass, Building building)
    {
        switch (buildingClass)
        {
            case EBuilding.Castle:
                buildings.Castle = (UnitCreator)building;
                return;
            case EBuilding.Farm:
                buildings.Farms.Add((ResourseCreator)building);
                return;
            case EBuilding.Barrack:
                buildings.Barracks.Add((UnitCreator)building);
                return;
            default:
                throw new Exception($"The player does not know about \"{buildingClass}\" class of buildings!");
        }
    }
    #endregion
    #region Units

    public void AddUnit(EUnitClass eUnit, BasicUnit unit)
    {
        switch (eUnit)
        {
            case EUnitClass.Worker:
                units.Workers.Add(unit);
                break;
            case EUnitClass.Warrior:
                units.Warriors.Add(unit);
                break;
            default:
                throw new Exception($"The player does not know about \"{eUnit}\" class of units!");
        }
    }

    private class Units
    {
        public List<BasicUnit> Workers = new();
        public List<BasicUnit> Warriors = new();
        public List<BasicUnit> Archers = new();
        public List<BasicUnit> Mages = new();
        public List<BasicUnit> Flys = new();
    }
    #endregion
}
