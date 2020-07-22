using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu_Cursor_Control : MonoBehaviour
{
    GameObject gm;
    GameObject Transition;

    public int SceneToLoad;

    public Image Cursor;
    public GameObject option1;
    public GameObject option2;

    private int numberOfOptions = 2;
    private int selectedOption;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("Master GameObject");
        Transition = GameObject.Find("LevelTransition");

        selectedOption = 1;
        Cursor.transform.position = option1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown("joystick button 0"))
        {
            Select();
        }
    }

    public void MoveDown()
    {
        selectedOption += 1;
        if (selectedOption > numberOfOptions) //If at end of list go back to top
        {
            selectedOption = 1;
        }

        switch (selectedOption) //Set the visual indicator for which option you are on.
        {
            case 1:
                Cursor.transform.position = option1.transform.position;
                break;
            case 2:
                Cursor.transform.position = option2.transform.position;
                break;
        }
    }

    public void MoveUp()
    {
        selectedOption -= 1;
        if (selectedOption < 1) //If at end of list go back to top
        {
            selectedOption = numberOfOptions;
        }

        switch (selectedOption) //Set the visual indicator for which option you are on.
        {
            case 1:
                Cursor.transform.position = option1.transform.position;
                break;
            case 2:
                Cursor.transform.position = option2.transform.position;
                break;
        }
    }

    public void Select()
    {
        Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

        switch (selectedOption) //Set the visual indicator for which option you are on.
        {
            case 1:
                Transition.GetComponent<Scene_Transition>().LoadNextScene(SceneToLoad);
                break;
            case 2:
                Application.Quit();
                break;
        }
    }
}
