using System;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    protected Player owner;

    public virtual void Initialize(Player player = null)
    {
        if (owner != null)
            throw new Exception("You cannot initialize an already initialized unit!");

        if (player != null)
            owner = player;
        else
            owner = BattleManager.GetPlayer();
    }

    public virtual void TakeHit()
    {

    }
}
