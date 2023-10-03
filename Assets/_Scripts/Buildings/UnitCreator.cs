using UniRx;
using UnityEngine;

public class UnitCreator : Building
{
    [SerializeField]
    private float productionSpeed;
    public FloatReactiveProperty ProductionRate = new();
    [SerializeField]
    private UnitClassEnum productionUnit;
    [SerializeField]
    private EBuilding buildingClass;
    public BoolReactiveProperty IsNeedNewUnit = new(true);

    public float MaxValue => battleBalance.GetProductionRate(productionUnit);

    private void Start()
    {
        owner.AddBuilding(buildingClass, this);
    }

    private void FixedUpdate()
    {
        if(ProductionRate.Value <= 0 && IsNeedNewUnit.Value)
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
        if (!IsNeedNewUnit.Value && owner.IsNeedMoreUnits(productionUnit))
            IsNeedNewUnit.Value = true;
    }

    private void CreateNewUnit()
    {
        IsNeedNewUnit.Value = false;

        GameObject newUnit = Instantiate(
            UnitDataBase.GetUnit(productionUnit),
            transform.position, 
            Quaternion.identity, 
            battleManager.GetParentTransform(owner));

        switch (productionUnit)
        {
            case UnitClassEnum.Worker:
                newUnit.GetComponent<Worker>().Initialize(owner, battleBalance.GetStats(productionUnit));
                break;
            default:
                newUnit.GetComponent<BasicUnit>().Initialize(owner, battleBalance.GetStats(productionUnit));
                break;
        }

        owner.AddUnit(productionUnit, newUnit.GetComponent<BasicUnit>());
    }
}