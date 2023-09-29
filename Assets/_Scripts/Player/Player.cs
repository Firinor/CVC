using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player
{
    private Resourses resourses;
    private Buildings buildings = new Buildings();
    private Units units = new Units();
    private Tañtic taktics = new Tañtic();
    private Dictionary<Unit, Building> unitWork = new();

    public bool IsAlive => buildings.Castle.IsAlive;

    public Vector3 CastlePosition => buildings.Castle.transform.position;

    #region Resourses
    private class Resourses
    {
        public int Food;
        public int Mineral;
    }
    public Transform FindNearestResources()
    {
        var result = from farm in buildings.FreeFarms
                     orderby farm.Distance()
                     select farm;

        Building resultFarm = result.First();

        buildings.FreeFarms.Remove(resultFarm);

        return resultFarm.Entrance;
    }
    public Transform FindNearestWarehouse(Vector3 position)
    {
        return buildings.Castle.Entrance;
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

    public void AddBuilding(BuildingClass buildingClass, Building building)
    {
        switch (buildingClass)
        {
            case BuildingClass.Castle:
                buildings.Castle = building;
                return;
            case BuildingClass.Farm:
                buildings.FreeFarms.Add(building);
                buildings.Farms.Add(building);
                return;
            case BuildingClass.Barrack:
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
        public List<Unit> Workers = new();
        public List<Unit> Warriors = new();
        public List<Unit> Archers = new();
        public List<Unit> Mages = new();
        public List<Unit> Flys = new();
    }
    #endregion
}
