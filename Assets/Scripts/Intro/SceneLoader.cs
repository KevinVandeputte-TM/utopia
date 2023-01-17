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
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        //LoadScene(0);
       LoadScene(index);
    }

    	void LoadScene(int sceneIndex)
    {
        Debug.Log("Load scene !");
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
        transition.LoadLevel(sceneIndex);
        //this is covered in the Transition.
        //SceneManager.LoadScene(SceneIndex);










    }

}
