using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UsingItem_State : State
{
    public UsingItem_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.IP_Cursor.transform.position = _system.PM_1.transform.position;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Select();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
            _system.SetState(new Inventory_State(_system));
        }
    }

    public void MoveLeft()
    {
        _system.currentOption -= 1;
        if (_system.currentOption < 1)
        {
            _system.currentOption = 2;
        }
    }

    public void MoveRight()
    {
        _system.currentOption += 1;
        if (_system.currentOption > 2)
        {
            _system.currentOption = 1;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        switch (_system.currentOption)
        {
            case 1:
                _system.IP_Cursor.transform.position = _system.PM_1.transform.position;
                break;
            case 2:
                _system.IP_Cursor.transform.position = _system.PM_2.transform.position;
                break;
        }
    }

    public override void Select()
    {
        switch (_system.currentOption)
        {
            case 1:
                UseItem0((ConsumableObject)_system.Inventory.GetItem(_system.selectedOption));
                _system.SetState(new Inventory_State(_system));
                break;
            case 2:
                UseItem1((ConsumableObject)_system.Inventory.GetItem(_system.selectedOption));
                _system.SetState(new Inventory_State(_system));
                break;
        }
    }

    public void UseItem0(ConsumableObject item)
    {
        GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue += item.restoreHealthValue;
        GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue += item.restoreSkillValue;

        _system.Inventory.RemoveItem(_system.selectedOption, 1);
        _system.itemsDisplayed[_system.Inventory.Container.Items[_system.selectedOption]].GetComponentInChildren<TextMeshProUGUI>().text = _system.Inventory.GetAmount(_system.selectedOption).ToString("n0");

        _system.miniStats1.UpdateStats();

        _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
        Debug.Log(item + " was used");
    }

    public void UseItem1(ConsumableObject item)
    {
        GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue += item.restoreHealthValue;
        GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue += item.restoreSkillValue;

        _system.Inventory.RemoveItem(_system.selectedOption, 1);
        _system.itemsDisplayed[_system.Inventory.Container.Items[_system.selectedOption]].GetComponentInChildren<TextMeshProUGUI>().text = _system.Inventory.GetAmount(_system.selectedOption).ToString("n0");

        _system.miniStats2.UpdateStats();

        _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
        Debug.Log(item + " was used");
    }
}
