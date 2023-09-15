public class BattleBalance
{
    private BattleBalanceScriptableObject battleBalance;

    private static BattleBalance instance;

    public static float GetProductionRate(UnitClass productionUnit)
    {
        return instance.battleBalance.GetProductionRate(productionUnit);
    }
}
