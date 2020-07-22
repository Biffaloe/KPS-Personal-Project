using System;
using System.Linq;
using System.Collections.Generic;

public class Stat_Modifiable : Base_Stat, IStatModifiable, IStatValueChange
{
    private List<Stat_Modifier> _statMods;
    private int _statModValue;

    public event EventHandler OnValueChange;

    public Stat_Modifiable()
    {
        _statModValue = 0;
        _statMods = new List<Stat_Modifier>();
    }

    protected void TriggerValueChange()
    {
        if (OnValueChange != null)
        {
            OnValueChange(this, null);
        }
    }

    public override int StatValue
    {
        get { return base.StatValue + StatModifierValue; }
    }

    public int StatModifierValue
    {
        get { return _statModValue; }
    }

    public void AddModifier(Stat_Modifier mod)
    {
        _statMods.Add(mod);
        mod.OnValueChange += OnModValueChange;
    }

    public void RemoveModifier(Stat_Modifier mod)
    {
        _statMods.Remove(mod);
        mod.OnValueChange -= OnModValueChange;
    }

    public void ClearModifiers()
    {
        foreach (var mod in _statMods)
        {  mod.OnValueChange -= OnModValueChange; }
        _statMods.Clear();
    }

    public void UpdateModifiers()
    {
        _statModValue = 0;

        var orderGroups = _statMods.OrderBy(m => m.Order).GroupBy(m => m.Order);
        foreach(var group in orderGroups)
        {
            float sum = 0, max = 0;
            foreach(var mod in group)
            {
                if (!mod.Stacks)
                {
                    if (mod.Value > max)
                    {
                        max = mod.Value;
                    }
                }
                else
                {
                    sum += mod.Value;
                }
            }

            _statModValue += group.First().ApplyModifier(
                StatBaseValue + _statModValue,
                (sum > max) ? sum : max);
        }

        TriggerValueChange();
    }

    public void OnModValueChange(object modifier, System.EventArgs args)
    {
        UpdateModifiers();
    }
}