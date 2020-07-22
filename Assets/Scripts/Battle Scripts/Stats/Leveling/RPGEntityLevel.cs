using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class RPGEntityLevel : MonoBehaviour
{
    [SerializeField]
    private int _Level = 1;

    [SerializeField]
    private int _LevelMin = 1;

    [SerializeField]
    private int _LevelMax = 99;

    private int _expCurrent = 0;
    private int _expRequired = 0;

    public EventHandler<RPGLevelChangeEventArgs> OnEntityLevelChange;
    public EventHandler<RPGLevelChangeEventArgs> OnEntityLevelUp;
    public EventHandler<RPGLevelChangeEventArgs> OnEntityLevelDown;
    public EventHandler<RPGExpGainEventArgs> OnEntityExpGain;

    public int Level
    {
        get { return _Level; }
        set { _Level = value; }
    }

    public int LevelMin
    {
        get { return _LevelMin; }
        set { _LevelMin = value; }
    }

    public int LevelMax
    {
        get { return _LevelMax; }
        set { _LevelMax = value; }
    }

    public int ExpCurrent
    {
        get { return _expCurrent; }
        private set { _expCurrent = value; }
    }

    public int ExpRequired
    {
        get { return _expRequired; }
        private set { _expRequired = value; }
    }


    #region EXP Stuff
    public abstract int GetExpRequiredForlevel(int level);

    private void Awake()
    {
        ExpRequired = GetExpRequiredForlevel(Level);
    }

    public void ModifyExp(int amount)
    {
        ExpCurrent += amount;


        if (OnEntityExpGain != null)
        {
            OnEntityExpGain(this, new RPGExpGainEventArgs(amount));
        }

        CheckCurrentExp();
    }

    public void SetCurrentExp(int value)
    {
        int expGained = value - ExpCurrent;
        ExpCurrent = value;

        if (OnEntityExpGain != null)
        {
            OnEntityExpGain(this, new RPGExpGainEventArgs(expGained));
        }

        CheckCurrentExp();
    }

    public void CheckCurrentExp()
    {
        int oldLevel = Level;

        InternalCheckCurrentExp();

        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new RPGLevelChangeEventArgs(Level, oldLevel));
        }
    }

    private void InternalCheckCurrentExp()
    {
        while (true)
        {
            if (ExpCurrent > ExpRequired)
            {
                ExpCurrent -= ExpRequired;
                InternalIncreaseCurrentLevel();
            }
            else if (ExpCurrent < 0)
            {
                ExpCurrent += GetExpRequiredForlevel(Level - 1);
                InternalDecreaseCurrentLevel();
            }
            else
                break;
        }
    }
    #endregion




    #region Levelup/down Stuff
    public void IncreaseCurrentLevel()
    {
        int oldLevel = Level;

        InternalIncreaseCurrentLevel();

        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new RPGLevelChangeEventArgs(Level, oldLevel));
        }
    }

    private void InternalIncreaseCurrentLevel()
    {
        int oldLevel = Level++;

        if (Level > LevelMax)
        {
            Level = LevelMax;
            ExpCurrent = GetExpRequiredForlevel(Level);
        }


        ExpRequired = GetExpRequiredForlevel(Level);
        if (oldLevel != Level && OnEntityLevelUp != null)
        {
            OnEntityLevelUp(this, new RPGLevelChangeEventArgs(Level, oldLevel));
        }
    }

    public void DecreaseCurrentLevel()
    {
        int oldLevel = Level;

        InternalDecreaseCurrentLevel();

        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new RPGLevelChangeEventArgs(Level, oldLevel));
        }
    }

    private void InternalDecreaseCurrentLevel()
    {
        int oldLevel = Level--;

        if (Level < LevelMin)
        {
            Level = LevelMin;
            ExpCurrent = 0;
        }

        ExpRequired = GetExpRequiredForlevel(Level);
        if (oldLevel != Level && OnEntityLevelDown != null)
        {
            OnEntityLevelDown(this, new RPGLevelChangeEventArgs(Level, oldLevel));
        }
    }

    public void SetLevel(int targetLevel)
    {
        SetLevel(targetLevel, true);
    }

    public void SetLevel(int targetLevel, bool clearExp)
    {
        int oldLevel = Level;

        Level = targetLevel;
        ExpRequired = GetExpRequiredForlevel(Level);

        if (clearExp)
        {
            SetCurrentExp(0);
        }
        else
        {
            InternalCheckCurrentExp();
        }

        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new RPGLevelChangeEventArgs(Level, oldLevel));
        }
    }
    #endregion
}