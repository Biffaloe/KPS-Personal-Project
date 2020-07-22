using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAttribute : Stat_Modifiable, IStatScalable, IStatLinkable
{
    private int _statLevelValue;
    private int _statLinkerValue;
    private List<Stat_Linker> _statLinkers;

    public int StatLevelValue
    {  get { return _statLevelValue; }  }

    public int StatLinkerValue
    {  get {  return _statLinkerValue;  }  }

    public override int StatBaseValue
    {  get {  return base.StatBaseValue + StatLevelValue + StatLinkerValue; }  }

    public virtual void ScaleStat(int level)
    {
        _statLevelValue = level;
        TriggerValueChange();
    }

    public void AddLinker(Stat_Linker linker)
    {
        _statLinkers.Add(linker);
        linker.OnValueChange += OnLinkerValueChange;
    }

    public void ClearLinkers()
    {
        foreach (var linker in _statLinkers)
        {   linker.OnValueChange -= OnLinkerValueChange;   }
        _statLinkers.Clear();
    }

    public void UpdateLinkers()
    {
        _statLinkerValue = 0;
        foreach (Stat_Linker link in _statLinkers)
        {
            _statLinkerValue += link.Value;
        }
        TriggerValueChange();
    }

    public StatAttribute()
    {
        _statLinkers = new List<Stat_Linker>();
    }

    private void OnLinkerValueChange(object linker, EventArgs args)
    {
        UpdateLinkers();
    }

}
