using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Field_Door : MonoBehaviour
{
    public int Door_ID;
    public int SceneToLoad;

    public Vector3 SpawnPoint;
    public Text InputText;
    GameObject gm;
    GameObject Transition;

    bool AbleToEnter = false;

    private void Start()
    {
        gm = GameObject.Find("Master GameObject");
        Transition = GameObject.Find("LevelTransition");
    }

    private void Update()
    {
        if (AbleToEnter && Input.GetKeyDown("c") && StateMachine.Inactive)
        {
            gm.GetComponent<GameMaster>().spawn = SpawnPoint;
            Transition.GetComponent<Scene_Transition>().LoadNextScene(SceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InputText.text = ("[c] to Enter");
            AbleToEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            InputText.text = (" ");
            AbleToEnter = false;
        }

    }
}
