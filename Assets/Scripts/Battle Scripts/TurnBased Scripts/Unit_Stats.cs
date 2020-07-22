using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit_Stats : MonoBehaviour, IComparable
{
    //0 = ally, 1 = Foe
    public int Side;
    public Unit_Stats(int side)
    {
        Side = side;
    }

    private Base_Stat_Collection _stats;
    public Base_Stat_Collection Stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    public int nextActTurn = 0;
    private bool dead = false;


    public void calculateNextActTurn(int currentTurn)
    {
        this.nextActTurn = currentTurn - (Stats.GetStat(Base_Stat_Type.Agi).StatValue);
    }
    public int CompareTo(object otherStats)
    {
        return nextActTurn.CompareTo(((Unit_Stats)otherStats).nextActTurn);
    }
    public bool isDead()
    {
        return this.dead;
    }
}
