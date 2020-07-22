using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_State : State
{
    public Status_State(New_Field_Menu system) : base(system)
    {
    }

    private int CurrentStats = 0;
    public override void Enter()
    {
        _system.anim.SetTrigger("Open Status");
        CurrentStats = _system.currentOption;
        DisplayUpdate();
        _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
    }

    public override void Handleinput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Cancel();
        }
    }

    public void MoveLeft()
    {
        _system.currentOption -= 1;
        if (_system.currentOption < 1)
        {
            _system.currentOption = 2;
        }

        CurrentStats = _system.currentOption;
        DisplayUpdate();
    }

    public void MoveRight()
    {
        _system.currentOption += 1;
        if (_system.currentOption > 2)
        {
            _system.currentOption = 1;
        }

        CurrentStats = _system.currentOption;
        DisplayUpdate();
    }

    public void DisplayUpdate()
    {
        switch (_system.currentOption)
        {
            case 1:
                UpdateStats_0();
                break;
            case 2:
                UpdateStats_1();
                break;
        }
    }

    public override void Cancel()
    {
        base.Cancel();

        _system.anim.SetTrigger("Close Status");
        _system.SetState(new Main_State(_system));
    }

    public void UpdateStats_0()
    {
        Base_Stat_Collection stats = GameMaster.PartyStats0;

        _system.Health.text = stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatBaseValue;
        _system.Mana.text = stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatBaseValue;

        _system.Strength.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Str).StatValue.ToString();
        _system.Magic.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mag).StatValue.ToString();
        _system.Defense.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Def).StatValue.ToString();
        _system.MagicDefense.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mdf).StatValue.ToString();
        _system.Agility.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Agi).StatValue.ToString();
    }
    public void UpdateStats_1()
    {
        Base_Stat_Collection stats = GameMaster.PartyStats1;

        _system.Health.text = stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatBaseValue;
        _system.Mana.text = stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatBaseValue;

        _system.Strength.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Str).StatValue.ToString();
        _system.Magic.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mag).StatValue.ToString();
        _system.Defense.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Def).StatValue.ToString();
        _system.MagicDefense.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mdf).StatValue.ToString();
        _system.Agility.text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Agi).StatValue.ToString();
    }
}
