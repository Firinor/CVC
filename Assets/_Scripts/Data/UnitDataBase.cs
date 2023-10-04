using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitDataBase
{
    private static UnitDataBase instance;
    
    private Dictionary<EUnitClass, GameObject> Units;

    public UnitDataBase(Dictionary<EUnitClass, GameObject> units)
    {
        instance = this;
        Units = units;
    }

    public static GameObject GetUnit(EUnitClass productionUnit)
    {
        return instance.Units[productionUnit];
    }
}