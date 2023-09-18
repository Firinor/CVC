using System;
using System.Collections.Generic;

public class Player
{
    private Resourses resourses;
    private Buildings buildings = new Buildings();
    private Units units = new Units();
    private Tañtic taktics = new Tañtic();

    public bool IsAlive => buildings.Castle.IsAlive;

    private class Resourses
    {
        public int Food;
        public int Mineral;
    }
    #region Buildings
    private class Buildings
    {
        public Building Castle;
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
