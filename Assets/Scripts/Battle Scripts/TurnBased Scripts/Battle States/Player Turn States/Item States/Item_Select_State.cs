using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item_Select_State : State_1
{
    public Item_Select_State(TurnSystem TSystem) : base(TSystem)
    {
    }

    public override void Enter()
    {
        _system.ItemMenu.transform.position = new Vector2(0, 0);
        _system.CreateInventoryDisplay();
    }
    public override void Exit()
    {
        _system.ItemMenu.transform.position = new Vector2(-600, -600);
        _system.EraseInventoryDisplay();
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
            _system.Initialize(new Item_Target_State(_system));
        }
    }

    public override void Cancel()
    {
        _system.ItemMenu.transform.position = new Vector2(-600, -600);
        _system.EraseInventoryDisplay();
        _system.SetState(new Select_Command_State(_system));
    }

    public void DisplayUpdate()
    {
        _system.Cursor.transform.position = _system.itemsDisplayed[_system.Inventory.Container.Items[_system.selectedOption]].transform.position;
    }

}
