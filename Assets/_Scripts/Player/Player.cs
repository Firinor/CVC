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
    }
    public IResourceCreator FindNearestResources()
    {
        var result = from farm in buildings.FreeFarms
                     orderby farm.Distance()
                     select farm;

        Building resultFarm = result.First();

        buildings.FreeFarms.Remove(resultFarm);

        return (IResourceCreator)resultFarm;
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

    public void AddBuilding(BuildingEnum buildingClass, Building building)
    {
        switch (buildingClass)
        {
            case BuildingEnum.Castle:
                buildings.Castle = building;
                return;
            case BuildingEnum.Farm:
                buildings.FreeFarms.Add(building);
                buildings.Farms.Add(building);
                return;
            case BuildingEnum.Barrack:
                buildings.Barracks.Add(building);
                return;
            default:
                throw new Exception($"The player does not know about \"{buildingClass}\" class of buildings!");
        }
    }
    #endregion
    #region Units
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
