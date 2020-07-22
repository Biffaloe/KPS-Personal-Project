using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGDefaultLevel : RPGEntityLevel
{
    public override int GetExpRequiredForlevel(int level)
    {
        return (int)(Mathf.Pow(level, 2f) * 10) + 10;
    }
}
