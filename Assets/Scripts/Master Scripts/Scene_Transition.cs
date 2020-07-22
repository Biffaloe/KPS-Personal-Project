using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_Transition : MonoBehaviour
{
    public float TransitionTime;

    public Animator transition;

    public void LoadNextScene(int levelindex)
    {
        StartCoroutine(LoadLevel(levelindex));
    }

    IEnumerator LoadLevel(int levelindex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(levelindex, LoadSceneMode.Single);
    }
}
