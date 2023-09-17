using System;
using UnityEngine;
using Zenject;

public class BattleManager : MonoBehaviour
{
    [Inject]
    private GameManager gameManager;
    [SerializeField]
    private bool IsClearLevel;

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
        if (IsClearLevel)
        {
            CleanLevel();
            BulidDefault();
        }
    }

    private void BulidDefault()
    {
        foreach (BuildingPosition buildingPosition in gameManager.DefaultBuildings)
        {
            var pos = new Vector3Int(buildingPosition.X, buildingPosition.Y);
            Instantiate(buildingPosition.Building, grid.CellToWorld(pos), Quaternion.identity, gridTransform);
        }
    }

    public static bool IsEnemyAlive(Player requester)
    {
        if (requester == instance.redPlayer)
            return instance.bluePlayer.IsAlive;
        else if (requester == instance.bluePlayer)
            return instance.redPlayer.IsAlive;
        else
            throw new Exception("The requesting player does not have a designated opponent!");
    }

    public static bool IsOwnerAlive(Player requester)
    {
        if (requester == instance.redPlayer)
            return instance.redPlayer.IsAlive;
        else if (requester == instance.bluePlayer)
            return instance.bluePlayer.IsAlive;
        else
            throw new Exception("The requesting player does not have an assigned place in the battle!");
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
