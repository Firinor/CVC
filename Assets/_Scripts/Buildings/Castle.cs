using UnityEngine;

public class Castle : Building
{
    [SerializeField]
    private Team team;
    [SerializeField]
    private float productionSpeed;
    private float productionRate;
    [SerializeField]
    private UnitClass productionUnit;
    private bool isNeedNewUnit = true;

    private void FixedUpdate()
    {
        if(productionRate <= 0 && isNeedNewUnit)
        {
            if (BattleManager.IsEnoughResources(productionUnit)) 
            {
                BattleManager.RemoveResources(team, productionUnit);
                productionRate += BattleBalance.GetProductionRate(productionUnit); 
            }
        }

        if(productionRate > 0)
        {
            productionRate -= productionSpeed * Time.fixedDeltaTime;
            if (productionRate <= 0)
            {
                CreateNewUnit();
                NeedNewUnit();
            }
        }
    }

    public void NeedNewUnit()
    {
        if (!isNeedNewUnit)
            isNeedNewUnit = true;
    }

    private void CreateNewUnit()
    {
        GameObject newUnit = Instantiate(
            UnitDataBase.GetUnit(productionUnit),
            transform.position, 
            Quaternion.identity, 
            BattleManager.GetTeamParent(team));

        newUnit.GetComponent<Unit>().Initialize(team, BattleBalance.GetStats(productionUnit));
    }
}