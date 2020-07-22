using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat_Linker : IStatValueChange
{
    private Base_Stat _stat;

    public event EventHandler OnValueChange;

    public Stat_Linker(Base_Stat stat)
    {
        _stat = stat;

        IStatValueChange iValueChange = _stat as IStatValueChange;
        if(iValueChange != null)
        {
            iValueChange.OnValueChange += OnLinkedStatValueChange;
        }
    }

    public Base_Stat Stat
    {
        get { return _stat; }
    }

    public abstract int Value { get; }

    private void OnLinkedStatValueChange(object stat, EventArgs args)
    {
        if (OnValueChange != null)
        {
            OnValueChange(this, null);
        }
    }
}
