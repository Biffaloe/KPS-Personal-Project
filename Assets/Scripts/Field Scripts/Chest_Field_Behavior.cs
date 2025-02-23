﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest_Field_Behavior : MonoBehaviour
{
    public int ChestId;
    public ItemObject Item;
    public Text InputText;
    public Sprite open;

    private bool AbleToopen = false;
    private GameObject gm;

    public GameObject chest;
    private Animator Anim;



    //gm ChestList[ChestId] == false allow chest to open and turn ChestList[ChestId] true
    private void Awake()
    {
        Anim = chest.GetComponent<Animator>();
        gm = GameObject.Find("Master GameObject");
        if (gm.GetComponent<GameMaster>().ChestList[ChestId] == true)
            this.GetComponent<SpriteRenderer>().sprite = open;
    }

    private void Update()
    {
        if (AbleToopen && Input.GetKeyDown("c") && gm.GetComponent<GameMaster>().ChestList[ChestId] == false)
            Open();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("In Chest Range");
        if (col.CompareTag("Player") && gm.GetComponent<GameMaster>().ChestList[ChestId] == false)
        {
            InputText.text = ("[c] to Open");
            AbleToopen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InputText.text = (" ");
            AbleToopen = false;
        }

    }

    private void Open()
    {
        gm.GetComponent<GameMaster>().ChestList[ChestId] = true;
        InputText.text = (" ");
        AbleToopen = false;
        this.GetComponent<SpriteRenderer>().sprite = open;
        gm.GetComponent<GameMaster>().Inventory.AddItem(Item, 1);
        Anim.SetTrigger("ItemGet");
    }

}
