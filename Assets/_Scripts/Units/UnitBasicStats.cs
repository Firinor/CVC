using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "GameBalance/UnitStats")]
public class UnitBasicStats : ScriptableObject
{
    public float Attack = 15;

    public float HealthPoint = 100;
    public float MaxHealthPoint = 100;

    public float DefenceRate;
    public float MaxDefenceRate = 100;

    public float Energy;
    public float MaxEnergy = 100;

    public float WorkSpeed = 2;

    public int BuffLimit = 2;
}
