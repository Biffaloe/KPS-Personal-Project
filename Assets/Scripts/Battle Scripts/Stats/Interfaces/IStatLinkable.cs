using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatLinkable
{
    int StatLinkerValue { get; }

    void AddLinker(Stat_Linker linker);
    void ClearLinkers();
    void UpdateLinkers();
}
