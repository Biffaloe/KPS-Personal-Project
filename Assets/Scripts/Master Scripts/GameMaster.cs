using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    static public Menu_State menu_State = Menu_State.Inactive;
    static public RPGEntityLevel PM0Level = new RPGDefaultLevel();
    static public RPGEntityLevel PM1Level = new RPGDefaultLevel();
    static public Base_Stat_Collection PartyStats0 = new PM0_Stats();
    static public Base_Stat_Collection PartyStats1 = new PM1_Stats();

    static public ItemObject P1Weapon;
    static public ItemObject P1Armor;
    static public ItemObject P1Accesory;

    static public ItemObject P2Weapon;
    static public ItemObject P2Armor;
    static public ItemObject P2Accesory;

    public InventoryObject Inventory;
    public GameObject Player;
    public Vector3 spawn;

    public List<bool> ChestList = new List<bool>();
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        PartyStats0.LinkStatsToLevel(PM0Level.Level, 4, 1.2f, 1.8f, 1.2f, 1.8f, 1.2f, 0.8f);
        PartyStats1.LinkStatsToLevel(PM1Level.Level, 2.5f, 2f, 1.2f, 1.8f, 1.2f, 1.8f, 0.82f);
    }
}