using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private Player redPlayer;
    [SerializeField]
    private Player bluePlayer;
    [SerializeField]
    private Transform redTeamParent;
    [SerializeField]
    private Transform blueTeamParent;
    [SerializeField]
    private Transform gridTransform;

    private static BattleManager instance;
    [SerializeField]
    private Grid grid;

    private void Awake()
    {
        instance = this;
        redPlayer = new Player();
        bluePlayer = new Player();
        BuildFirstBuildings();
    }

    private void BuildFirstBuildings()
    {
        CleanLevel();

    }

    private void CleanLevel()
    {
        GameCleaner.DeleteAllChild(redTeamParent);
        GameCleaner.DeleteAllChild(blueTeamParent);
        GameCleaner.DeleteAllChild(gridTransform);
    }

    public static Player GetPlayer()
    {
        return instance.redPlayer;
    }
    public static Transform GetParentTransform(Player player)
    {
        if(player == instance.redPlayer)
            return instance.redTeamParent;
        else if (player == instance.bluePlayer)
            return instance.blueTeamParent;
        else
            throw new Exception("Could not find a transform for the specified command!");
    }

    public static bool IsEnoughResources(UnitClass productionUnit)
    {
        return true;
    }

    public static void RemoveResources(Player player, UnitClass productionUnit)
    {
        
    }
}
