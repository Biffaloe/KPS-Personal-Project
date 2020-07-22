using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Status_Mini : MonoBehaviour
{
    public TMPro.TMP_Text HPDisplay;
    public TMPro.TMP_Text MPDisplay;

    Stat_Vital HP;
    Stat_Vital MP;

    private void Start()
    {
        HP = GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.HP);
        MP = GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.MP);

        HPDisplay.text = "HP: " + HP.StatCurrentValue + "/" + HP.StatBaseValue;
        MPDisplay.text = "MP: " + MP.StatCurrentValue + "/" + MP.StatBaseValue;
    }

    public void UpdateStats()
    {
        HPDisplay.text = "HP: " + HP.StatCurrentValue + "/" + HP.StatBaseValue;
        MPDisplay.text = "MP: " + MP.StatCurrentValue + "/" + MP.StatBaseValue;
    }
}
