using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatrixStats : MonoBehaviour
{
    int CurrentLv;
    int CurrentHp;
    int CurrentMp;
    int CurrentStr;
    int CurrentInt;
    int CurrentDef;
    int CurrentSpr;
    int CurrentSpd;
    int CurrentLck;

    void Awake()
    {
        CharacterStats Beatrix = new CharacterStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
