using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_Stats : Base_Stat_Collection
{
    protected override void ConfigureStats(int HP, int MP, int STR, int MAG, int DEF, int MDF, int AGI)
    {
        var Hp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.HP);
        Hp.StatName = "HP";
        Hp.StatBaseValue = HP;

        var Mp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.MP);
        Mp.StatName = "MP";
        Mp.StatBaseValue = MP;

        var Str = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Str);
        Str.StatName = "Strength";
        Str.StatBaseValue = STR;

        var Mag = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mag);
        Mag.StatName = "Magic";
        Mag.StatBaseValue = MAG;

        var Def = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Def);
        Def.StatName = "Defense";
        Def.StatBaseValue = DEF;

        var Mdf = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mdf);
        Mdf.StatName = "Magic Defense";
        Mdf.StatBaseValue = MDF;

        var Agi = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Agi);
        Agi.StatName = "Agility";
        Agi.StatBaseValue = AGI;
    }
}