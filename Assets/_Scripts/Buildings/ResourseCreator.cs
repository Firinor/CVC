using UniRx;
using UnityEngine;

public class ResourseCreator : Building
{
    [SerializeField]
    private float productionSpeed;
    public FloatReactiveProperty ProductionRate = new();
    public bool IsFoodReady;
    [SerializeField]
    private Resource resource;
    [SerializeField]
    private BuildingClass buildingClass;

    public float WorkRequired => battleBalance.GetProductionRate(resource);

    private void Start()
    {
        owner.AddBuilding(buildingClass, this);
    }

    private void FixedUpdate()
    {
        if (ProductionRate.Value <= 0 && !IsFoodReady)
        {
            ProductionRate.Value += battleBalance.GetFarmRate();
        }

        if (ProductionRate.Value > 0)
        {
            ProductionRate.Value -= productionSpeed * Time.fixedDeltaTime;
            if (ProductionRate.Value <= 0)
            {
                IsFoodReady = true;
            }
        }
    }
}
