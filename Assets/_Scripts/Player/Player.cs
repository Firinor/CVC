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

    private class Buildings
    {
        public Castle Castle;
        public List<Building> Farms = new();
        public List<Building> Barraks = new();
        public List<Building> Towers = new();
        public List<Building> Houses = new();
    }

    private class Units
    {
        public List<Unit> Workers = new();
        public List<Unit> Warriors = new();
        public List<Unit> Archers = new();
        public List<Unit> Mages = new();
        public List<Unit> Flys = new();
    }
    public void AddCastle(Castle castle)
    {
        buildings.Castle = castle;
    }

    public void AddFarm(Building farm)
    {
        buildings.Farms.Add(farm);
    }
}
