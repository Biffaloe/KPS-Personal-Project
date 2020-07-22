using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM1_Stats : Base_Stat_Collection
{
    protected override void ConfigureStats()
    {
        var Hp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.HP);
        Hp.StatName = "HP";
        Hp.StatBaseValue = 40;

        var Mp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.MP);
        Mp.StatName = "MP";
        Mp.StatBaseValue = 23;

        var Str = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Str);
        Str.StatName = "Strength";
        Str.StatBaseValue = 5;

        var Mag = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mag);
        Mag.StatName = "Magic";
        Mag.StatBaseValue = 7;

        var Def = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Def);
        Def.StatName = "Defense";
        Def.StatBaseValue = 4;

        var Mdf = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mdf);
        Mdf.StatName = "Magic Defense";
        Mdf.StatBaseValue = 6;

        var Agi = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Agi);
        Agi.StatName = "Agility";
        Agi.StatBaseValue = 4;
    }

    public void LinkStats(int level)
    {
        var Level = CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale);
        Level.StatName = "LevelScale";
        Level.StatBaseValue = level;

        var Hp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.HP);
        Hp.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 2.5f));
        Hp.UpdateLinkers();
        Hp.SetCurrentValueToMax();

        var Mp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.MP);
        Mp.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 2f));
        Mp.UpdateLinkers();
        Mp.SetCurrentValueToMax();

        var Str = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Str);
        Str.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1f));
        Str.UpdateLinkers();

        var Mag = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mag);
        Mag.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.8f));
        Mag.UpdateLinkers();

        var Def = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Def);
        Def.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1f));
        Def.UpdateLinkers();

        var Mdf = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mdf);
        Mdf.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.8f));
        Mdf.UpdateLinkers();

        var Agi = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Agi);
        Agi.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 0.9f));
        Agi.UpdateLinkers();
    }
}
