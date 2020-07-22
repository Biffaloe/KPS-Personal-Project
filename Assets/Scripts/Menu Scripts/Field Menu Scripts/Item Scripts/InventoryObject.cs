using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public Inventory Container;

    public void AddItem(ItemObject _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if(Container.Items[i].item.Id == _item.Id)
            {
                Container.Items[i].AddAmount(_amount);
                return;
            }
        }
        Container.Items.Add(new InventorySlot(_item, _amount));
    }

    public void RemoveItem(int _item, int _amount)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (i == _item)
            {
                if (Container.Items[i].amount > 0)
                    Container.Items[i].RemoveAmount(_amount);
                else
                    Container.Items.RemoveAt(_item);
                break;
            }
        }
    }

    public ItemObject GetItem(int _index)
    {
       return Container.Items[_index].item;
    }
    public int GetAmount(int _index)
    {
        return Container.Items[_index].amount;
    }

    public Vector2 GetPostition(int i, int X, int Y, int Y_Space)
    {
        int X_Start = X;
        int Y_Start = Y;
        int Y_Space_Between_Items = Y_Space;

        return new Vector2(X_Start, Y_Start - (Y_Space_Between_Items * i));
    }
}




[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public void RemoveAmount(int value)
    {
        amount -= value;
    }
}

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}
