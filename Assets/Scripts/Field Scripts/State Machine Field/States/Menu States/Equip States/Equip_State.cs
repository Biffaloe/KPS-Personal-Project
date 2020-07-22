using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Equip_State : State
{
    public Equip_State(New_Field_Menu system) : base(system)
    {
    }

    public override void Enter()
    {
        _system.anim.SetTrigger("Open Equip");
        _system.currentOption = 0;
        DisplayUpdate();
    }

    public override void Handleinput()
    {
        base.Handleinput();
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
            _system.anim.SetTrigger("Close Equip");
            _system.E_Cursor.transform.position = new Vector2(-1000, 0);
            _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
            _system.SetState(new Main_State(_system));
        }
    }

    public void MoveUp()
    {
        _system.currentOption -= 1;
        if (_system.currentOption < 1)
        {
            _system.currentOption = _system.numberOfOptions;
        }
    }

    public void MoveDown()
    {
        _system.currentOption += 1;
        if (_system.currentOption > _system.numberOfOptions)
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
                _system.E_Cursor.transform.position = new Vector2(_system.Wpn_transform.position.x - 180, _system.Wpn_transform.position.y);
                break;
            case 2:
                _system.E_Cursor.transform.position = new Vector2(_system.Armor_transform.position.x - 150, _system.Armor_transform.position.y);
                break;
            case 3:
                _system.E_Cursor.transform.position = new Vector2(_system.Acc_transform.position.x - 175, _system.Acc_transform.position.y);
                break;
        }
    }

    public override void Select()
    {
        switch (_system.currentOption)
        {
            case 1:
                _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
                _system.Initialize(new EquipWpn_State(_system));
                break;
            case 2:
                _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
                _system.Initialize(new EquipArmor_State(_system));
                break;
            case 3:
                _system.IP_Cursor.transform.position = new Vector2(-1000, 0);
                _system.Initialize(new EquipAcc_State(_system));
                break;
        }
    }

    public void DisplayUpdate()
    {
        switch (_system.currentPM)
        {
            case 1:
                UpdateStats_0();
                if (GameMaster.P1Weapon != null)
                    _system.EquipWeapon.GetComponentInChildren<Image>().sprite = GameMaster.P1Weapon.uiDisplay;
                else
                    _system.EquipWeapon.GetComponentInChildren<Image>().sprite = _system.EmptySlot.uiDisplay;
                if (GameMaster.P1Armor != null)
                    _system.EquipArmor.GetComponentInChildren<Image>().sprite = GameMaster.P1Armor.uiDisplay;
                else
                    _system.EquipArmor.GetComponentInChildren<Image>().sprite = _system.EmptySlot.uiDisplay;
                if (GameMaster.P1Accesory != null)
                    _system.EquipAccesory.GetComponentInChildren<Image>().sprite = GameMaster.P1Accesory.uiDisplay;
                else
                    _system.EquipAccesory.GetComponentInChildren<Image>().sprite = _system.EmptySlot.uiDisplay;
                break;
            case 2:
                UpdateStats_1();
                if (GameMaster.P2Weapon != null)
                    _system.EquipWeapon.GetComponentInChildren<Image>().sprite = GameMaster.P2Weapon.uiDisplay;
                else
                    _system.EquipWeapon.GetComponentInChildren<Image>().sprite = _system.EmptySlot.uiDisplay;
                if (GameMaster.P2Armor != null)
                    _system.EquipArmor.GetComponentInChildren<Image>().sprite = GameMaster.P2Armor.uiDisplay;
                else
                    _system.EquipArmor.GetComponentInChildren<Image>().sprite = _system.EmptySlot.uiDisplay;
                if (GameMaster.P2Accesory != null)
                    _system.EquipAccesory.GetComponentInChildren<Image>().sprite = GameMaster.P2Accesory.uiDisplay;
                else
                    _system.EquipAccesory.GetComponentInChildren<Image>().sprite = _system.EmptySlot.uiDisplay;
                break;
        }
    }

    public void UpdateStats_0()
    {
        Base_Stat_Collection stats = GameMaster.PartyStats0;

        GameObject Health = GameObject.Find("Equip_HP_Text");
        GameObject Mana = GameObject.Find("Equip_MP_Text");
        GameObject Strength = GameObject.Find("Equip_Str_Text");
        GameObject Magic = GameObject.Find("Equip_Mag_Text");
        GameObject Defense = GameObject.Find("Equip_Def_Text");
        GameObject MagicDefense = GameObject.Find("Equip_Mdf_Text");
        GameObject Agility = GameObject.Find("Equip_Agi_Text");

        Health.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatBaseValue;
        Mana.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatBaseValue;

        Strength.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Str).StatValue.ToString() + " + " + ReturnStatBonusStr1();
        Magic.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mag).StatValue.ToString() + " + " + ReturnStatBonusMag1();
        Defense.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Def).StatValue.ToString() + " + " + ReturnStatBonusDef1();
        MagicDefense.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mdf).StatValue.ToString() + " + " + ReturnStatBonusMdf1();
        Agility.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Agi).StatValue.ToString() + " + " + ReturnStatBonusAgi1();
    }
    public void UpdateStats_1()
    {
        Base_Stat_Collection stats = GameMaster.PartyStats1;

        GameObject Health = GameObject.Find("Equip_HP_Text");
        GameObject Mana = GameObject.Find("Equip_MP_Text");
        GameObject Strength = GameObject.Find("Equip_Str_Text");
        GameObject Magic = GameObject.Find("Equip_Mag_Text");
        GameObject Defense = GameObject.Find("Equip_Def_Text");
        GameObject MagicDefense = GameObject.Find("Equip_Mdf_Text");
        GameObject Agility = GameObject.Find("Equip_Agi_Text");

        Health.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatBaseValue;
        Mana.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue + "/" + stats.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatBaseValue;

        Strength.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Str).StatValue.ToString() + " + " + ReturnStatBonusStr2();
        Magic.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mag).StatValue.ToString() + " + " + ReturnStatBonusMag2();
        Defense.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Def).StatValue.ToString() + " + " + ReturnStatBonusDef2();
        MagicDefense.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Mdf).StatValue.ToString() + " + " + ReturnStatBonusMdf2();
        Agility.GetComponent<TMP_Text>().text = stats.GetStat<Stat_Modifiable>(Base_Stat_Type.Agi).StatValue.ToString() + " + " + ReturnStatBonusAgi2();
    }


    private int ReturnStatBonusStr1()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P1Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P1Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P1Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.atkBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.atkBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.atkBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusMag1()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P1Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P1Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P1Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.magBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.magBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.magBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusDef1()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P1Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P1Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P1Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.defBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.defBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.defBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusMdf1()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P1Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P1Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P1Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.mdfBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.mdfBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.mdfBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusAgi1()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P1Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P1Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P1Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.agiBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.agiBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.agiBonus;
        }

        return bonus;
    }


    private int ReturnStatBonusStr2()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P2Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P2Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P2Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.atkBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.atkBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.atkBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusMag2()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P2Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P2Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P2Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.magBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.magBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.magBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusDef2()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P2Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P2Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P2Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.defBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.defBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.defBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusMdf2()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P2Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P2Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P2Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.mdfBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.mdfBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.mdfBonus;
        }

        return bonus;
    }
    private int ReturnStatBonusAgi2()
    {
        int bonus = 0;
        WeaponObject Wpn = (WeaponObject)GameMaster.P2Weapon;
        ArmorObject Arm = (ArmorObject)GameMaster.P2Armor;
        AccesoryObject Acc = (AccesoryObject)GameMaster.P2Accesory;

        if (Wpn != null)
        {
            bonus += (int)Wpn.agiBonus;
        }
        if (Arm != null)
        {
            bonus += (int)Arm.agiBonus;
        }
        if (Acc != null)
        {
            bonus += (int)Acc.agiBonus;
        }

        return bonus;
    }
}
