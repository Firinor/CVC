using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private Transform RedTeamParent;
    [SerializeField]
    private Transform BlueTeamParent;

    private static BattleManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static Transform GetTeamParent(Team team)
    {
        switch (team)
        {
            case Team.Red:
                return instance.RedTeamParent;
            case Team.Blue:
                return instance.BlueTeamParent;
            default:
                throw new Exception("Could not find a transform for the specified command!");
        }
    }

    public static bool IsEnoughResources(UnitClass productionUnit)
    {
        return true;
    }

    public static void RemoveResources(Team team, UnitClass productionUnit)
    {
        
    }
}
