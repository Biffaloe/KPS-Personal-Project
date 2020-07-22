using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatModTotalAdd : Stat_Modifier
{
    public override int Order
    {
        get { return 4; }
    }

    public override int ApplyModifier(int statValue, float modValue)
    {
        return (int)(modValue);
    }

    public StatModTotalAdd(float value) : base(value) { }
    public StatModTotalAdd(float value, bool stacks) : base(value, stacks) { }
}