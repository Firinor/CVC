using UnityEngine;

public class Farm : Building
{
    [SerializeField]
    private float productionSpeed;
    private float productionRate;
    public bool IsFoodReady;

    private void Start()
    {
        owner.AddFarm(this);
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
