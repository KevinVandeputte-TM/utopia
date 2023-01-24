using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    private Transition transition;
    [Header("Index van scene om naar toe te gaan:")]
    public int index;
    
    //when enabled
    void OnEnable(){
       LoadScene(index);
    }

    	void LoadScene(int sceneIndex)
    {
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
        transition.LoadLevel(sceneIndex);
    }

}
