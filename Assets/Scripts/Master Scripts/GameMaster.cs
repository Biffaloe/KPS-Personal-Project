using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    public GameObject Player;
    public Vector3 spawn;

    public List<bool> ChestList = new List<bool>();
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
