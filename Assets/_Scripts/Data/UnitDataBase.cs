using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitDataBase
{
    private static UnitDataBase instance;
    
    private Dictionary<UnitClass, GameObject> Units;

    public UnitDataBase(Dictionary<UnitClass, GameObject> units)
    {
        instance = this;
        Units = units;
    }

    public static GameObject GetUnit(UnitClass productionUnit)
    {
        return instance.Units[productionUnit];
    }
}