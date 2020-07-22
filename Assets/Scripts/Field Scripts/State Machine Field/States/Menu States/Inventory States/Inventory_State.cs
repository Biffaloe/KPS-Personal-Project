using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_State : State
{
    public Inventory_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.anim.SetTrigger("Open Item");
        _system.CreateInventoryDisplay();
        _system.selectedOption = 0;
        _system.I_Cursor.transform.position = _system.itemsDisplayed[_system.Equipment.Container.Items[0]].transform.position;
    }

    public override void Handleinput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Select();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Cancel();
        }
    }

    public virtual void MoveUp()
    {
        _system.selectedOption -= 1;
        if (_system.selectedOption < 0)
        {
            _system.selectedOption = _system.Inventory.Container.Items.Count - 1;
        }

        DisplayUpdate();
    }

    public virtual void MoveDown()
    {
        _system.selectedOption += 1;
        if (_system.selectedOption > _system.Inventory.Container.Items.Count - 1)
        {
            _system.selectedOption = 0;
        }

        DisplayUpdate();
    }

    public override void Select()
    {
        base.Select();
        if (_system.Inventory.Container.Items[_system.selectedOption].item.type == ItemType.Consumable)
        {
            _system.Initialize(new UsingItem_State(_system));
        }
    }

    public override void Cancel()
    {
        base.Cancel();
        _system.anim.SetTrigger("Close Item");
        _system.EraseInventoryDisplay();
        _system.SetState(new Main_State(_system));
    }

    public void DisplayUpdate()
    {
        _system.I_Cursor.transform.position = _system.itemsDisplayed[_system.Inventory.Container.Items[_system.selectedOption]].transform.position;
    }
}
