using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
 
    public Animator transition;


    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(DelayLoadLevel(sceneIndex));
    }

    IEnumerator DelayLoadLevel(int sceneIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait for 1 sec
        yield return new WaitForSeconds(1);
        //load scene
        SceneManager.LoadScene(sceneIndex);
    }
}