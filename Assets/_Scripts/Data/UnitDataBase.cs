using System.Collections.Generic;

public class UnitDataBase
{
    private static UnitDataBase instance;
    private Dictionary<UnitClass, Unit> Units;

    public static Unit GetUnit(UnitClass productionUnit)
    {
        return instance.Units[productionUnit];
    }
}