using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class TurnSystem : StateMachine_1
{
    [SerializeField]
    private int X_Start, Y_Start, Y_Space;


    private List<Unit_Stats> unitStats;
    private int index = 0;
    public int selectedOption = 0;
    public bool IsTurnOver = false;

    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    public InventoryObject Inventory;
    public ItemObject EmptySlot;

    public Display_Battle_Status_PM0 Stats_0;
    public Display_Battle_Status_PM1 Stats_1;

    public GameObject InventoryPrefab;
    public GameObject ActionsMenu, ItemMenu, PM_1, PM_2, Cursor, IP_Cursor;

    private void Start()
    {
        Initialize(new Select_Command_State(this));

        unitStats = new List<Unit_Stats>
        {
            new Unit_Stats_PM0(),
            new Unit_Stats_PM1(),
            new Enemy_Stats_0()
        };

        foreach (Unit_Stats unit in unitStats)
        {
            unit.calculateNextActTurn(0);
        }

        unitStats.Sort();

        this.ActionsMenu.SetActive(false);
        this.nextTurn();
    }

    private void Update()
    {
        CurrentState.Handleinput();

        CurrentState.LogicUpdate();

        if (IsTurnOver)
        {
            index++;
            nextTurn();
        }
    }


    public void nextTurn()
    {
        if (index < 3)
        {
            Unit_Stats currentUnit = unitStats[index];

            if (!currentUnit.isDead())
            {
                if (currentUnit.Side == 0)
                {
                    Debug.Log("Player Turn");
                    ChangeState(new Select_Command_State(this));
                }
                else
                {
                    //ChangeState(new Enemy_Turn_State(this));
                    ChangeState(new End_Turn_State(this));
                    Debug.Log("Enemy Turn");
                }
            }
        }
        else
        {
            index = 0;
        }
    }


   

    public void CreateInventoryDisplay()
    {
        for (int i = 0; i < Inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = Inventory.Container.Items[i];
            {
                var obj = Instantiate(InventoryPrefab, Vector2.zero, Quaternion.identity, transform);
                obj.transform.SetParent(ItemMenu.transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.item.uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = Inventory.GetPostition(i, X_Start, Y_Start, Y_Space);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                obj.transform.GetChild(0).GetComponentInChildren<Image>().SetNativeSize();
                itemsDisplayed.Add(slot, obj);
            }
        }
        Cursor.transform.position = itemsDisplayed[Inventory.Container.Items[0]].transform.position;
    }

    public void EraseInventoryDisplay()
    {
        for (int i = 0; i < Inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = Inventory.Container.Items[i];
            if (itemsDisplayed.ContainsKey(slot))
                Destroy(itemsDisplayed[slot]);
        }
        itemsDisplayed.Clear();
        Cursor.transform.position = new Vector2(-1000, 0);
    }
}