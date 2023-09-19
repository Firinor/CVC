using Buffs;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utility;
using Utility.UniRx;
using Zenject;

public class Unit : MonoBehaviour
{
    [Inject]
    private GameManager gameManager;
    [Inject]
    private BattleManager battleManager;

    private Player owner;

    [field: SerializeField]
    public NavMeshAgent NavMeshAgent { get; private set; }
    private UnitPattern behavior;
    [SerializeField]
    private UnitBehaviour<Unit> startBehaviour;
    [SerializeField]
    private Transform target;
    public Vector3 Target => target.position;

    [SerializeField]
    private SpriteRenderer unitSprite;
    private UnitBasisStats basisStats;
    private UnitAttributes currentStats = new UnitAttributes()
    {
        {Attribute.Attack, new LimitedFloatReactiveProperty() },
        {Attribute.Defence, new LimitedFloatReactiveProperty() },
        {Attribute.Health, new LimitedFloatReactiveProperty() },
        {Attribute.Energy, new LimitedFloatReactiveProperty() }
    };
    public ReactiveCollection<Buff> Buffs;
    public bool IsDead => currentStats[Attribute.Health].Value <= 0;
    private float HealthPoint
    {
        get { return currentStats[Attribute.Health].Value; }
        set
        {
            currentStats[Attribute.Health].Value = value;
            if (value <= 0)
                ToDead();
        }
    }
    public bool IsEnemyAlive => battleManager.IsEnemyAlive(owner);
    public bool IsOwnerAlive => battleManager.IsOwnerAlive(owner);
    public bool IsNearTarget => Vector3.Distance(transform.position, Target) < 0.1f;

    public LimitedFloatReactiveProperty this[Attribute key] => currentStats[key];


    public void Initialize(Player player, UnitBasisStats stats, UnitBehaviour<Unit> startBehaviour)
    {
        if (owner != null)
            throw new Exception("You cannot initialize an already initialized unit!");

        owner = player;
        basisStats = stats;
        behavior = new UnitPattern(startBehaviour, this);

        InitStats();
    }

    private void InitStats()
    {
        InitAttack();
        InitHealth();
        InitDefence();
    }
    private void InitAttack()
    {
        var stat = currentStats[Attribute.Attack];
        stat.MinLimit = true;
        stat.MinValue = 1;
        stat.Value = basisStats.Attack;
    }
    private void InitHealth()
    {
        var stat = currentStats[Attribute.Health];
        stat.MaxLimit = true;
        stat.MaxValue = basisStats.MaxHealthPoint;
        stat.Value = basisStats.HealthPoint;
    }
    private void InitDefence()
    {
        var stat = currentStats[Attribute.Defence];
        stat.MinLimit = true;
        stat.MinValue = 0;
        stat.MaxLimit = true;
        stat.MaxValue = basisStats.MaxDefenceRate;
        stat.Value = basisStats.DefenceRate;

    }
    public void FindNearestResources()
    {
        target = owner.FindNearestResources();
    }

    public void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        behavior.Tick();
    }

    private void ToDead()
    {
        throw new NotImplementedException();
    }
    public bool IsEnemyInRange()
    {
        throw new NotImplementedException();
    }


    public void Attack()
    {
        //if(MissCheck()) return;

        AttackData damage = GenerateAttackData();

        //BoostWithEquipment(damage);
        //BoostWithCrit(damage);
        BoostWithBuffs(ref damage);

        //float totalDamageDone = target.TakeHit(damage);
    }
    private AttackData GenerateAttackData()
    {
        return new AttackData() { 
            {Attribute.Attack, currentStats[Attribute.Attack].Value} 
        };
    }
    private void BoostWithBuffs(ref AttackData damage)
    {
        foreach(Buff buff in Buffs)
        {
            buff.Decorate(damage);
        }
    }
    public void AddToAttribute(KeyValuePair<Attribute, float> attribute)
    {
        AddToAttribute(attribute.Key, attribute.Value);
    }
    public void RemoveFromAttribute(KeyValuePair<Attribute, float> attribute)
    {
        AddToAttribute(attribute.Key, -attribute.Value);
    }
    private void AddToAttribute(Attribute attribute, float value)
    {
        currentStats[attribute].Value += value;
    }
    private float TakeHit(AttackData attackData)
    {
        float totalDamageDone = 0;

        foreach (var attack in attackData)
        {
            if (attack.Key == Attribute.Attack)
                totalDamageDone = TakeDamage(attack.Value * attackData.Multiplicator);
            else
                currentStats[attack.Key].Value += attack.Value * attackData.Multiplicator;
        }

        return totalDamageDone;
    }
    private float TakeDamage(float damage)
    {
        damage = Ratios.ReduceByPercentage(damage, currentStats[Attribute.Defence].Value);

        if (damage <= 0)
            return 0;

        float lostHealthPoint = Math.Min(damage, HealthPoint);

        HealthPoint -= damage;

        return lostHealthPoint;
    }
    private BuffCore[] GetCurrentBuffCores()
    {
        BuffCore[] result = new BuffCore[Buffs.Count];

        for(int i = 0; i < Buffs.Count; i++)
        {
            result[i] = Buffs[i].BuffCore;
        }

        return result;
    }
    public void AddBuff(BuffCore buffBehaviour)
    {
        Buff buff = new Buff();
        buff.Start(this, buffBehaviour);

        Buffs.Add(buff);
    }

    public void SetBehavior(UnitBehaviour<Unit> newBehavior)
    {
        behavior.SetState(newBehavior);
    }
}
