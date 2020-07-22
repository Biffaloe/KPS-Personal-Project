using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Stat_Collection
{
    private Dictionary<Base_Stat_Type, Base_Stat> _statDict;

    public Dictionary<Base_Stat_Type, Base_Stat> StatDict
    {
        get
        {
            if (_statDict == null)
            {
                _statDict = new Dictionary<Base_Stat_Type, Base_Stat>();
            }
            return _statDict;
        }
    }

    public Base_Stat_Collection()
    {
        ConfigureStats();
    }

    public Base_Stat_Collection(int HP, int MP, int Str, int Mag, int Def, int Mdf, int Agi)
    {
        ConfigureStats(HP, MP, Str, Mag, Def, Mdf, Agi);
    }

    protected virtual void ConfigureStats()
    {
    }

    protected virtual void ConfigureStats(int HP, int MP, int STR, int MAG, int DEF, int MDF, int AGI)
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

    public bool ContainStat(Base_Stat_Type stat_Type)
    {
        return StatDict.ContainsKey(stat_Type);
    }

    public Base_Stat GetStat(Base_Stat_Type stat_Type)
    {
        if (ContainStat(stat_Type))
        {
            return StatDict[stat_Type];
        }
        return null;
    }

    public T GetStat<T>(Base_Stat_Type type) where T : Base_Stat
    {
        return GetStat(type) as T;
    }

    protected T CreateStat<T>(Base_Stat_Type stat_Type) where T : Base_Stat
    { 
        T stat = System.Activator.CreateInstance<T>();
        StatDict.Add(stat_Type, stat);
        return stat;
    }

    protected T CreateOrGetStat<T>(Base_Stat_Type stat_Type) where T : Base_Stat
    {
        T stat = GetStat<T>(stat_Type);
        if (stat == null)
        {
            stat = CreateStat<T>(stat_Type);
        }
        return stat;
    }

    public void LinkStatsToLevel(int level, float HPmod, float MPmod, float STRmod, float MAGmod, float DEFmod, float MDFmod, float AGImod)
    {
        var Level = CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale);
        Level.StatName = "LevelScale";
        Level.StatBaseValue = level;

        var Hp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.HP);
        Hp.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), HPmod));
        Hp.UpdateLinkers();
        Hp.SetCurrentValueToMax();

        var Mp = CreateOrGetStat<Stat_Vital>(Base_Stat_Type.MP);
        Mp.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), MPmod));
        Mp.UpdateLinkers();
        Mp.SetCurrentValueToMax();

        var Str = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Str);
        Str.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), STRmod));
        Str.UpdateLinkers();

        var Mag = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mag);
        Mag.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), MAGmod));
        Mag.UpdateLinkers();

        var Def = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Def);
        Def.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), DEFmod));
        Def.UpdateLinkers();

        var Mdf = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Mdf);
        Mdf.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), MDFmod));
        Mdf.UpdateLinkers();

        var Agi = CreateOrGetStat<StatAttribute>(Base_Stat_Type.Agi);
        Agi.AddLinker(new Stat_Linker_Basic(CreateOrGetStat<StatAttribute>(Base_Stat_Type.LevelScale), AGImod));
        Agi.UpdateLinkers();
    }
}
