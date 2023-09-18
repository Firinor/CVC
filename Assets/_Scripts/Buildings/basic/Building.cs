using System;
using UnityEngine;
using Zenject;

public abstract class Building : MonoBehaviour
{
    [Inject]
    protected BattleBalance battleBalance;
    [Inject]
    protected BattleManager battleManager;
    [SerializeField]
    private float currentHealth;
    public bool IsAlive => currentHealth > 0;

    protected Player owner;

    public virtual void Initialize(Player player)
    {
        if (owner != null)
            throw new Exception("You cannot initialize an already initialized unit!");

        owner = player;
    }

    public virtual void TakeHit()
    {

    }
}
