using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BattleBalanceScriptableObject battleBalance;
    [SerializeField]
    private BattleBalance balance;
    [SerializeField]
    private UnitDataBase units;
    [SerializeField]
    private List<UnitKeyValuePair> unitsPrefabs;

    private void Awake()
    {
        balance = new BattleBalance(battleBalance);

        Dictionary<UnitClass, GameObject> unitsDictionary = new();
        foreach (var pair in unitsPrefabs)
            unitsDictionary.Add(pair.unitClass, pair.unit);

        units = new UnitDataBase(unitsDictionary);
    }

    [Serializable]
    private class UnitKeyValuePair
    {
        public UnitClass unitClass;
        public GameObject unit;
    }
}
