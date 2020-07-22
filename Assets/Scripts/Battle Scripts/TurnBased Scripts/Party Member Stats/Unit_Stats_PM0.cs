using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Stats_PM0 : Unit_Stats
{
    public Unit_Stats_PM0() : base(0)
    {
        Stats = GameMaster.PartyStats0;
    }
}
