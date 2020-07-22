using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class New_Field_Menu : StateMachine
{
    public Image Cursor;
    public Image I_Cursor;
    public Image IP_Cursor;
    public Image E_Cursor;

    public Transform Wpn_transform;
    public Transform Armor_transform;
    public Transform Acc_transform;

    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
    public GameObject PM_1;
    public GameObject PM_2;
    public GameObject InventoryPrefab;
    public GameObject EquipWeapon;
    public GameObject EquipArmor;
    public GameObject EquipAccesory;

    public Animator anim;
    public int numberOfOptions = 4;
    public int selectedOption;
    public int currentOption;
    public int currentPM;
    public int X_Start;
    public int Y_Space;
    public int Y_Start;


    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    public Dictionary<InventorySlot, GameObject> EquipmentDisplayed = new Dictionary<InventorySlot, GameObject>();
    public InventoryObject Equipment;
    public InventoryObject Inventory;
    public ItemObject EmptySlot;

    public Display_Status_Mini miniStats1;
    public Display_Status_Mini_2 miniStats2;
    public TMPro.TMP_Text Health;
    public TMPro.TMP_Text Mana;

    public TMPro.TMP_Text Strength;
    public TMPro.TMP_Text Magic;
    public TMPro.TMP_Text Defense;
    public TMPro.TMP_Text MagicDefense;
    public TMPro.TMP_Text Agility;

    public void Start()
    {
        anim = this.GetComponent<Animator>();

        miniStats1 = GameObject.Find("Char_Profile 1").GetComponent<Display_Status_Mini>();
        miniStats2 = GameObject.Find("Char_Profile 2").GetComponent<Display_Status_Mini_2>();

        GameMaster.PartyStats0.GetStat<Stat_Vital>(Base_Stat_Type.HP).StatCurrentValue = 10;
        GameMaster.PartyStats1.GetStat<Stat_Vital>(Base_Stat_Type.MP).StatCurrentValue = 0;

        SetState(new Inactive_State(this));
        StateMachine.Inactive = true;

        miniStats1.UpdateStats();
        miniStats2.UpdateStats();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (StateMachine.Inactive)
            {
                Initialize(new Begin_State(this));
            }
            else
            {
                Initialize(new Close_State(this));
            }
        }

        CurrentState.Handleinput();

        CurrentState.LogicUpdate();
    }


    public void CreateInventoryDisplay()
    {
        for (int i = 0; i < Inventory.Container.Items.Count; i++)
        {
            InventorySlot slot = Inventory.Container.Items[i];
            {
                var obj = Instantiate(InventoryPrefab, Vector2.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.item.uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = Inventory.GetPostition(i, X_Start, Y_Start, Y_Space);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                itemsDisplayed.Add(slot, obj);
            }
        }
        I_Cursor.transform.position = itemsDisplayed[Inventory.Container.Items[0]].transform.position;
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
        I_Cursor.transform.position = new Vector2(-1000, 0);
    }




    public void CreateEquipmentDisplay()
    {
        for (int i = 0; i < Equipment.Container.Items.Count; i++)
        {
            InventorySlot slot = Equipment.Container.Items[i];

            {
                var obj = Instantiate(InventoryPrefab, Vector2.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.item.uiDisplay;
                obj.GetComponent<RectTransform>().localPosition = Equipment.GetPostition(i, X_Start, Y_Start, Y_Space);
                itemsDisplayed.Add(slot, obj);
            }
        }
        I_Cursor.transform.position = itemsDisplayed[Equipment.Container.Items[0]].transform.position;
    }


    public void EraseEquipmentDisplay()
    {
        for (int i = 0; i < Equipment.Container.Items.Count; i++)
        {
            InventorySlot slot = Equipment.Container.Items[i];
            if (itemsDisplayed.ContainsKey(slot))
                Destroy(itemsDisplayed[slot]);
        }
        itemsDisplayed.Clear();
        I_Cursor.transform.position = new Vector2(-1000, 0);
    }
}
