using UnityEngine;

public class ResourseCreator : Building
{
    [SerializeField]
    private float productionSpeed;
    private float productionRate;
    public bool IsFoodReady;
    [SerializeField]
    private Resource resource;
    [SerializeField]
    private BuildingClass buildingClass;

    private void Start()
    {
        owner.AddBuilding(buildingClass, this);
    }

    private void FixedUpdate()
    {
        if (productionRate <= 0 && !IsFoodReady)
        {
            productionRate += battleBalance.GetFarmRate();
        }

        if (productionRate > 0)
        {
            productionRate -= productionSpeed * Time.fixedDeltaTime;
            if (productionRate <= 0)
            {
                IsFoodReady = true;
            }
        }
    }
}
