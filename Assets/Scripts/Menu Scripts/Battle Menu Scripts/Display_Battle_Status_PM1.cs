using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Display_Battle_Status_PM1 : MonoBehaviour
{
    //meh
    [SerializeField]
    private Image HealthBar;
    [SerializeField]
    private Image ManaBar;
    [SerializeField]
    private TMPro.TMP_Text HPText;
    [SerializeField]
    private TMPro.TMP_Text MPText;

    Stat_Vital HP;
    Stat_Vital MP;

    private float BarWidth;

    private void Awake()
    {
        HP = GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.HP);
        MP = GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.MP);

        HPText.text = "HP: " + HP.StatCurrentValue + "/" + HP.StatBaseValue;
        MPText.text = "MP: " + MP.StatCurrentValue + "/" + MP.StatBaseValue;

        BarWidth = 100 * (HP.StatCurrentValue / HP.StatBaseValue);
        HealthBar.rectTransform.sizeDelta = new Vector2(BarWidth, HealthBar.rectTransform.sizeDelta.y);

        BarWidth = 100 * (MP.StatCurrentValue / MP.StatBaseValue);
        ManaBar.rectTransform.sizeDelta = new Vector2(BarWidth, HealthBar.rectTransform.sizeDelta.y);
    }

    public void UpdateDisplay()
    {
        HPText.text = "HP: " + HP.StatCurrentValue + "/" + HP.StatBaseValue;
        MPText.text = "MP: " + MP.StatCurrentValue + "/" + MP.StatBaseValue;

        BarWidth = 100 * (HP.StatCurrentValue / HP.StatBaseValue);
        HealthBar.rectTransform.sizeDelta = new Vector2(BarWidth, HealthBar.rectTransform.sizeDelta.y);

        BarWidth = 100 * (MP.StatCurrentValue / MP.StatBaseValue);
        ManaBar.rectTransform.sizeDelta = new Vector2(BarWidth, HealthBar.rectTransform.sizeDelta.y);
    }

}