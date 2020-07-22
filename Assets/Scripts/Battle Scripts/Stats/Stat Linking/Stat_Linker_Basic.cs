using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat_Linker_Basic : Stat_Linker
{
    private float _ratio;

    public override int Value
    {
        get { return (int)(Stat.StatValue * _ratio); }
    }

    public Stat_Linker_Basic(Base_Stat stat, float ratio) : base(stat)
    {
        _ratio = ratio;
    }
}
