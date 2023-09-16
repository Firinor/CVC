using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{
    [SerializeField]
    private float productionSpeed;
    private float productionRate;
    public bool IsFoodReady;

    private void Start()
    {
        Initialize();
        owner.AddFarm(this);
    }

    private void FixedUpdate()
    {
        if (productionRate <= 0 && !IsFoodReady)
        {
            productionRate += BattleBalance.GetFarmRate();
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
