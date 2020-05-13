using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Scene_Spawner : MonoBehaviour
{
    private void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        GameObject gm = GameObject.Find("Master GameObject");
        Vector3 Spawn = gm.GetComponent<GameMaster>().spawn;

        if (Spawn != null)
            Player.transform.position = Spawn;
        else
            Player.transform.position = new Vector3(0, 0, 0);
    }
}
