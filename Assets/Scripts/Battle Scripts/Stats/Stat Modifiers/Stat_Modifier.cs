using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat_Modifier
{
    private float _value;

    public event EventHandler OnValueChange;
    public abstract int Order { get; }
    public bool Stacks { get; set; }



    public float Value
    {
        get { return _value; }
        set
        {
            if (_value != value)
            {
                _value = value;
                if(OnValueChange != null)
                {
                    OnValueChange(this, null);
                }
            }
        }
    }


    public Stat_Modifier()
    {
        Value = 0;
        Stacks = false;
    }
    public Stat_Modifier(float value)
    {
        Value = value;
        Stacks = false;
    }

    public Stat_Modifier(float value, bool stacks)
    {
        Value = value;
        Stacks = stacks;
    }

    public abstract int ApplyModifier(int statValue, float modValue);
}
