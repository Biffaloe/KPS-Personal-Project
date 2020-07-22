using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGExpGainEventArgs : EventArgs
{
    public int ExpGained { get; private set; }

    public RPGExpGainEventArgs(int expgained)
    {
        ExpGained = expgained;
    }
}
