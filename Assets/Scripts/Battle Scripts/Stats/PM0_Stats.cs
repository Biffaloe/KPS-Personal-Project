using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM0_Stats : Base_Stat_Collection
{
    protected override void ConfigureStats()
    {
        var Hp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.HP);
        Hp.StatName = "HP";
        Hp.StatBaseValue = 60;

        var Mp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.MP);
        Mp.StatName = "MP";
        Mp.StatBaseValue = 12;

        var Str = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Str);
        Str.StatName = "Strength";
        Str.StatBaseValue = 7;

        var Mag = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mag);
        Mag.StatName = "Magic";
        Mag.StatBaseValue = 5;

        var Def = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Def);
        Def.StatName = "Defense";
        Def.StatBaseValue = 6;

        var Mdf = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mdf);
        Mdf.StatName = "Magic Defense";
        Mdf.StatBaseValue = 4;

        var Agi = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Agi);
        Agi.StatName = "Agility";
        Agi.StatBaseValue = 3;
    }

    public void LinkStats(int level)
    {
        var Level = CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale);
        Level.StatName = "LevelScale";
        Level.StatBaseValue = level;

        var Hp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.HP);
        Hp.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 4f));
        Hp.UpdateLinkers();
        Hp.SetCurrentValueToMax();

        var Mp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.MP);
        Mp.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.2f));
        Mp.UpdateLinkers();
        Mp.SetCurrentValueToMax();

        var Str = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Str);
        Str.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.8f));
        Str.UpdateLinkers();

        var Mag = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mag);
        Mag.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.2f));
        Mag.UpdateLinkers();

        var Def = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Def);
        Def.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.8f));
        Def.UpdateLinkers();

        var Mdf = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mdf);
        Mdf.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 1.2f));
        Mdf.UpdateLinkers();

        var Agi = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Agi);
        Agi.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), 0.8f));
        Agi.UpdateLinkers();
    }
}
