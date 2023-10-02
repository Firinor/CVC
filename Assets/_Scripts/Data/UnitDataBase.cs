using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitDataBase
{
    private static UnitDataBase instance;
    
    private Dictionary<UnitClassEnum, GameObject> Units;

    public UnitDataBase(Dictionary<UnitClassEnum, GameObject> units)
    {
        instance = this;
        Units = units;
    }

    public static GameObject GetUnit(UnitClassEnum productionUnit)
    {
        return instance.Units[productionUnit];
    }
}