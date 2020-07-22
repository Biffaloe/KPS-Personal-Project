using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StatVitalTest : MonoBehaviour
{
    private Base_Stat_Collection stats;

    void Start()
    {
        stats = new PM0_Stats();

        var health = stats.GetStat<Stat_Vital>(Base_Stat_Type.HP);
        health.OnCurrentValueChange += OnStatValueChange;

        DisplayStatValues();

        health.StatCurrentValue -= 30;

        DisplayStatValues();
    }

    void OnStatValueChange(object sender, EventArgs args)
    {
        Stat_Vital vital = (Stat_Vital)sender;
        if (vital != null)
        {
            Debug.Log(string.Format("Vital {0}'s OnStatValueChange event was triggered", vital.StatName));
        }
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
                Stat_Vital vital = stat as Stat_Vital;
                if(vital != null)
                {
                    Debug.Log(string.Format("Stat {0}'s value is {1}/{2}",
                        stat.StatName, vital.StatCurrentValue, stat.StatValue));
                }
                else
                {
                    Debug.Log(string.Format("Stat {0}'s value is {1}",
                        stat.StatName, stat.StatValue));
                }
            }
        });
    }
}
