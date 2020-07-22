using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipAcc_State : State
{
    public EquipAcc_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Cancel()
    {
        _system.EraseEquipmentDisplay();
        _system.anim.SetTrigger("Equip Item Close");
        _system.Initialize(new Equip_State(_system));
    }

    public override void Enter()
    {
        _system.anim.SetTrigger("Equip Item Open");
        _system.CreateEquipmentDisplay();
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
            _system.selectedOption = _system.Equipment.Container.Items.Count - 1;
        }

        DisplayUpdate();
    }

    public virtual void MoveDown()
    {
        _system.selectedOption += 1;
        if (_system.selectedOption > _system.Equipment.Container.Items.Count - 1)
        {
            _system.selectedOption = 0;
        }

        DisplayUpdate();
    }

    public void DisplayUpdate()
    {
        _system.I_Cursor.transform.position = _system.itemsDisplayed[_system.Equipment.Container.Items[_system.selectedOption]].transform.position;
    }

    public override void Select()
    {
        if (_system.Equipment.Container.Items[_system.selectedOption].item.type == ItemType.Weapon)
        {
            switch (_system.currentPM)
            {
                case 1:
                    if (GameMaster.P1Accesory == null)
                    {
                        _system.Equipment.RemoveItem(_system.selectedOption, 1);
                        GameMaster.P1Accesory = _system.Equipment.Container.Items[_system.selectedOption].item;
                    }
                    else
                    {
                        _system.Equipment.AddItem(GameMaster.P1Weapon, 1);
                        GameMaster.P1Accesory = _system.Equipment.Container.Items[_system.selectedOption].item;
                        _system.Equipment.RemoveItem(_system.selectedOption, 1);
                    }
                    Cancel();
                    break;
                case 2:
                    if (GameMaster.P2Accesory == null)
                    {
                        _system.Equipment.RemoveItem(_system.selectedOption, 1);
                        GameMaster.P2Accesory = _system.Equipment.Container.Items[_system.selectedOption].item;
                    }
                    else
                    {
                        _system.Equipment.AddItem(GameMaster.P2Weapon, 1);
                        GameMaster.P2Accesory = _system.Equipment.Container.Items[_system.selectedOption].item;
                        _system.Equipment.RemoveItem(_system.selectedOption, 1);
                    }
                    Cancel();
                    break;
            }
        }
    }
}
