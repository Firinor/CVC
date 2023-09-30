using System;
using UnityEngine;
using Zenject;

public class BattleManager : MonoBehaviour
{
    [Inject]
    private GameManager gameManager;
    [Inject]
    private BuildingsFactory buildingsFactory;
    [Inject]
    private BattleBalance battleBalance;
    [SerializeField]
    private bool IsClearLevel;

    [Inject(Id = "RedPlayer")]
    private Player redPlayer;
    [Inject(Id = "BluePlayer")]
    private Player bluePlayer;
    [SerializeField]
    private Transform redTeamParent;
    [SerializeField]
    private Transform blueTeamParent;
    [SerializeField]
    private Transform gridTransform;

    [SerializeField]
    private Grid grid;

    private void Awake()
    {
        BuildFirstBuildings();
    }

    private void BuildFirstBuildings()
    {
        if (IsClearLevel)
        {
            CleanLevel();
            buildingsFactory.BulidDefault();
        }
    }

    public bool IsEnemyAlive(Player requester)
    {
        if (requester == redPlayer)
            return bluePlayer.IsAlive;
        else if (requester == bluePlayer)
            return redPlayer.IsAlive;
        else
            throw new Exception("The requesting player does not have a designated opponent!");
    }

    public bool IsOwnerAlive(Player requester)
    {
        if (requester == redPlayer)
            return redPlayer.IsAlive;
        else if (requester == bluePlayer)
            return bluePlayer.IsAlive;
        else
            throw new Exception("The requesting player does not have an assigned place in the battle!");
    }

    private void CleanLevel()
    {
        GameCleaner.DeleteAllChild(redTeamParent);
        GameCleaner.DeleteAllChild(blueTeamParent);
        GameCleaner.DeleteAllChild(gridTransform);
    }

    public Player GetPlayer()
    {
        return redPlayer;
    }
    public Transform GetParentTransform(Player player)
    {
        if(player == redPlayer)
            return redTeamParent;
        else if (player == bluePlayer)
            return blueTeamParent;
        else
            throw new Exception("Could not find a transform for the specified command!");
    }

    public bool IsEnoughResources(UnitClass productionUnit)
    {
        return true;
    }

    public void RemoveResources(Player player, UnitClass productionUnit)
    {
        
    }

    //public float GetAmountOfWork(BuildingClass building)
    //{
    //    switch (building)
    //    {
    //        case BuildingClass.Farm:
    //            return battleBalance.GetFarmRate();
    //        case BuildingClass.Mine:
    //        //return battleBalance.GetMineWork();
    //        default:
    //            throw new Exception("This class of buildings does not have a definition of the amount of work!");
    //    }
    //}
}
