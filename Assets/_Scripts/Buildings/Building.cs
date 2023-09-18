using System;
using UnityEngine;
using Zenject;

public class Building : MonoBehaviour
{
    [Inject]
    protected BattleBalance battleBalance;
    [Inject]
    protected BattleManager battleManager;
    [SerializeField]
    private float currentHealth;
    public bool IsAlive => currentHealth > 0;

    [Inject(Id = "RedPlayer")]
    protected Player owner;

    //[Inject]
    //public virtual void Initialize(Player player = null)
    //{
    //    if (owner != null)
    //        throw new Exception("You cannot initialize an already initialized unit!");

    //    if (player != null)
    //        owner = player;
    //    else
    //        owner = battleManager.GetPlayer();
    //}

    public virtual void TakeHit()
    {

    }
}
