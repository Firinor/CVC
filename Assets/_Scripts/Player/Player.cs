using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    private Resourses resourses;
    private Buildings buildings = new Buildings();
    private Units units = new Units();
    private Tactic taktics = new Tactic();
    private Dictionary<BasicUnit, Building> unitWork = new();

    public bool IsAlive => buildings.Castle.IsAlive;

    public Vector3 CastlePosition => buildings.Castle.transform.position;

    #region Resourses
    private class Resourses
    {
        public int Food;
        public int Mineral;

        public void AddResource(ResourcePack resourcePack)
        {
            var resources = resourcePack.Resources;
            for(int i = 0; i < resources.Length; i++)
            {
                switch (resources[i].Resource)
                {
                    case ResourceEnum.Food:
                        Food += resources[i].Count;
                        break;
                    case ResourceEnum.Mineral:
                        Mineral += resources[i].Count;
                        break;
                    default:
                        throw new ArgumentException($"The player is trying to get an unknown type of resource: {resources[i].Resource}!");
                }
            }
        }
    }
    public IResourceCreator FindNearestResources()
    {
        var result = from farm in buildings.FreeFarms
                     orderby farm.Distance()
                     select farm;

        if (result.Any())
        {
            Building resultFarm = result.First();

            buildings.FreeFarms.Remove(resultFarm);

            return (IResourceCreator)resultFarm;
        }

        return null;
    }

    public void GetResources(List<IItem> inventory)
    {
        for (int i = 0; inventory.Count < i;)
        {
            if(inventory[i] is ResourcePack resourcePack)
            {
                resourses.AddResource(resourcePack);
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
        public Building Castle;
        public List<Building> FreeFarms = new();
        public List<Building> Farms = new();
        public List<Building> Barracks = new();
        public List<Building> Towers = new();
        public List<Building> Houses = new();
    }

    public bool IsNeedMoreUnits(UnitClassEnum unitClass)
    {
        switch (unitClass)
        {
            case UnitClassEnum.Worker:
                return units.Workers.Count < taktics.WorkersLimit;
            case UnitClassEnum.Warrior:
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
                buildings.Castle = building;
                return;
            case EBuilding.Farm:
                buildings.FreeFarms.Add(building);
                buildings.Farms.Add(building);
                return;
            case EBuilding.Barrack:
                buildings.Barracks.Add(building);
                return;
            default:
                throw new Exception($"The player does not know about \"{buildingClass}\" class of buildings!");
        }
    }
    #endregion
    #region Units

    public void AddUnit(UnitClassEnum eUnit, BasicUnit unit)
    {
        switch (eUnit)
        {
            case UnitClassEnum.Worker:
                units.Workers.Add(unit);
                break;
            case UnitClassEnum.Warrior:
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
