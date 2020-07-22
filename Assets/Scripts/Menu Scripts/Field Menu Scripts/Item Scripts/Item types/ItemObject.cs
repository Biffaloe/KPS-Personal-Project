using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    Weapon,
    Armor,
    Accesory,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
}

