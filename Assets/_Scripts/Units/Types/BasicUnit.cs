using Buffs;
using FirUnityEditor;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;
using Utility;
using Utility.UniRx;
using Zenject;

public abstract class BasicUnit : MonoBehaviour, ITarget
{
    [Inject]
    private GameManager gameManager;
    [Inject]
    private BattleManager battleManager;

    protected Player owner;

    [field: SerializeField]
    public NavMeshAgent NavMeshAgent { get; private set; }

    protected List<IItem> inventory = new();
    public ITarget Target { get; protected set; }
    public Vector3 Position => transform.position;

    public bool IsSleep;

    [SerializeField]
    private SpriteRenderer unitSprite;
    protected UnitBasicStats basisStats;
    protected UnitAttributes currentStats = new UnitAttributes()
    {
        {EUnitAttribute.Attack, new LimitedFloatReactiveProperty() },
        {EUnitAttribute.Defence, new LimitedFloatReactiveProperty() },
        {EUnitAttribute.Health, new LimitedFloatReactiveProperty() },
        {EUnitAttribute.Energy, new LimitedFloatReactiveProperty() }
    };
    public ReactiveCollection<Buff> Buffs;
    public bool IsDead => currentStats[EUnitAttribute.Health].Value <= 0;
    private float HealthPoint
    {
        get { return currentStats[EUnitAttribute.Health].Value; }
        set
        {
            currentStats[EUnitAttribute.Health].Value = value;
            if (value <= 0)
                ToDead();
        }
    }
    public bool IsEnemyAlive => battleManager.IsEnemyAlive(owner);
    public bool IsOwnerAlive => battleManager.IsOwnerAlive(owner);
    public bool IsNearTarget => Vector3.Distance(transform.position, Target.Position) < 0.1f;

    public LimitedFloatReactiveProperty this[EUnitAttribute key] => currentStats[key];

    public virtual void Initialize(Player player, UnitBasicStats stats)
    {
        if (owner != null)
            throw new Exception("You cannot initialize an already initialized unit!");

        owner = player;
        basisStats = stats;

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
        var stat = currentStats[EUnitAttribute.Attack];
        stat.MinLimit = true;
        stat.MinValue = 1;
        stat.Value = basisStats.Attack;
    }
    private void InitHealth()
    {
        var stat = currentStats[EUnitAttribute.Health];
        stat.MaxLimit = true;
        stat.MaxValue = basisStats.MaxHealthPoint;
        stat.Value = basisStats.HealthPoint;
    }
    private void InitDefence()
    {
        var stat = currentStats[EUnitAttribute.Defence];
        stat.MinLimit = true;
        stat.MinValue = 0;
        stat.MaxLimit = true;
        stat.MaxValue = basisStats.MaxDefenceRate;
        stat.Value = basisStats.DefenceRate;

    }

    public void FindNearestWarehouse()
    {
        Target = owner.FindNearestWarehouse(transform.position);
    }
    public void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
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
            {EUnitAttribute.Attack, currentStats[EUnitAttribute.Attack].Value} 
        };
    }
    private void BoostWithBuffs(ref AttackData damage)
    {
        foreach(Buff buff in Buffs)
        {
            buff.Decorate(damage);
        }
    }
    public void AddToAttribute(KeyValuePair<EUnitAttribute, float> attribute)
    {
        AddToAttribute(attribute.Key, attribute.Value);
    }
    public void RemoveFromAttribute(KeyValuePair<EUnitAttribute, float> attribute)
    {
        AddToAttribute(attribute.Key, -attribute.Value);
    }
    private void AddToAttribute(EUnitAttribute attribute, float value)
    {
        currentStats[attribute].Value += value;
    }
    private float TakeHit(AttackData attackData)
    {
        float totalDamageDone = 0;

        foreach (var attack in attackData)
        {
            if (attack.Key == EUnitAttribute.Attack)
                totalDamageDone = TakeDamage(attack.Value * attackData.Multiplicator);
            else
                currentStats[attack.Key].Value += attack.Value * attackData.Multiplicator;
        }

        return totalDamageDone;
    }
    private float TakeDamage(float damage)
    {
        damage = Ratios.ReduceByPercentage(damage, currentStats[EUnitAttribute.Defence].Value);

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
}
