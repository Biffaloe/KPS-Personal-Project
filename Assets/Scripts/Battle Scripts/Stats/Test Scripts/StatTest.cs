using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTest : MonoBehaviour
{
    private Base_Stat_Collection stats;

    void Start()
    {
        stats = new PM0_Stats();

        DisplayStatValues();

        var health = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.HP);

        health.AddModifier(new StatModBasePercent(1.0f));
        health.AddModifier(new StatModBaseAdd(50.0f));
        health.AddModifier(new StatModTotalAdd(10.0f));
        health.AddModifier(new StatModTotalPercent(2.0f));
        health.UpdateModifiers();


       // stats.GetStat<StatAttribute>(Base_Stat_Type.HealthScale).ScaleStat(10);
       // stats.GetStat<StatAttribute>(Base_Stat_Type.ManaScale).ScaleStat(5);

        DisplayStatValues();
    }

    void ForEachEnum<T>(Action<T> action)
    {
        if (action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues()
    {
        ForEachEnum<Base_Stat_Type>((statType) => {
            Base_Stat stat = stats.GetStat((Base_Stat_Type)statType);
            if (stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}",
                    stat.StatName, stat.StatValue));
            }
        });
    }
}
