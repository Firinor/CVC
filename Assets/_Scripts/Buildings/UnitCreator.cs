using UniRx;
using UnityEngine;

public class UnitCreator : Building
{
    [SerializeField]
    private float productionSpeed;
    public FloatReactiveProperty ProductionRate = new();
    [SerializeField]
    private UnitClass productionUnit;
    [SerializeField]
    private BuildingClass buildingClass;
    private bool isNeedNewUnit = true;

    public float MaxValue => battleBalance.GetProductionRate(productionUnit);

    private void Start()
    {
        owner.AddBuilding(buildingClass, this);
    }

    private void FixedUpdate()
    {
        if(ProductionRate.Value <= 0 && isNeedNewUnit)
        {
            if (battleManager.IsEnoughResources(productionUnit)) 
            {
                battleManager.RemoveResources(owner, productionUnit);
                ProductionRate.Value += MaxValue; 
            }
        }

        if(ProductionRate.Value > 0)
        {
            ProductionRate.Value -= productionSpeed * Time.fixedDeltaTime;
            if (ProductionRate.Value <= 0)
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
            battleManager.GetParentTransform(owner));

        newUnit.GetComponent<Unit>().Initialize(owner, battleBalance.GetStats(productionUnit));
    }
}