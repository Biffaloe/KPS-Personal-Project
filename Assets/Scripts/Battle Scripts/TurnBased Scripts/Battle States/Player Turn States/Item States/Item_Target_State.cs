using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item_Target_State : State_1
{
    public Item_Target_State(TurnSystem TSystem) : base(TSystem)
    {
    }

    int currentOption = 0;

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
            _system.SetState(new Item_Select_State(_system));
        }
    }

    public void MoveLeft()
    {
        currentOption -= 1;
        if (currentOption < 1)
        {
            currentOption = 2;
        }
    }

    public void MoveRight()
    {
        currentOption += 1;
        if (currentOption > 2)
        {
            currentOption = 1;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        switch (currentOption)
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
        switch (currentOption)
        {
            case 1:
                UseItem0((ConsumableObject)_system.Inventory.GetItem(_system.selectedOption));
                _system.ItemMenu.transform.position = new Vector2(-600, -600);
                _system.EraseInventoryDisplay();
                _system.ChangeState(new End_Turn_State(_system));
                break;
            case 2:
                UseItem1((ConsumableObject)_system.Inventory.GetItem(_system.selectedOption));
                _system.ItemMenu.transform.position = new Vector2(-600, -600);
                _system.EraseInventoryDisplay();
                _system.ChangeState(new End_Turn_State(_system));
                break;
        }
    }

    public void UseItem0(ConsumableObject item)
    {
        GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue += item.restoreHealthValue;
        GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue += item.restoreSkillValue;

        _system.Inventory.RemoveItem(_system.selectedOption, 1);
        _system.itemsDisplayed[_system.Inventory.Container.Items[_system.selectedOption]].GetComponentInChildren<TextMeshProUGUI>().text = _system.Inventory.GetAmount(_system.selectedOption).ToString("n0");

        _system.Stats_0.UpdateDisplay();

        _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
        Debug.Log(item + " was used");
    }

    public void UseItem1(ConsumableObject item)
    {
        GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue += item.restoreHealthValue;
        GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue += item.restoreSkillValue;

        _system.Inventory.RemoveItem(_system.selectedOption, 1);
        _system.itemsDisplayed[_system.Inventory.Container.Items[_system.selectedOption]].GetComponentInChildren<TextMeshProUGUI>().text = _system.Inventory.GetAmount(_system.selectedOption).ToString("n0");

        _system.Stats_1.UpdateDisplay();

        _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
        Debug.Log(item + " was used");
    }

}
