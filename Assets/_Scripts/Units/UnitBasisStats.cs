using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "GameBalance/UnitStats")]
public class UnitBasisStats : ScriptableObject
{
    public float Attack = 15;

    public float HealthPoint = 100;
    public float MaxHealthPoint = 100;

    public float DefenceRate;
    public float MaxDefenceRate = 100;

    public float Energy;
    public float MaxEnergy = 100;

    public int BuffLimit = 2;
}
