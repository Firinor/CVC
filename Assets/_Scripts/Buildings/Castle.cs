using UnityEngine;

public class Castle : Building
{
    [SerializeField]
    private float productionSpeed;
    private float productionRate;
    [SerializeField]
    private UnitClass productionUnit;
    private bool isNeedNewUnit = true;

    private void Start()
    {
        Initialize();
        owner.AddCastle(this);
    }

    private void FixedUpdate()
    {
        if(productionRate <= 0 && isNeedNewUnit)
        {
            if (BattleManager.IsEnoughResources(productionUnit)) 
            {
                BattleManager.RemoveResources(owner, productionUnit);
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
            BattleManager.GetParentTransform(owner));

        newUnit.GetComponent<Unit>().Initialize(owner, BattleBalance.GetStats(productionUnit));
    }
}