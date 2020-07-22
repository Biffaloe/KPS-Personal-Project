using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats_0 : Unit_Stats
{
    public Enemy_Stats_0() : base(1)
    {
        Stats = new Base_Stat_Collection(50, 99, 5, 5, 5, 5, 15);
    }

}
