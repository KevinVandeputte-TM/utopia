using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public bool correctanswer;
    GameObject scripts;
    Start_World worldControl;

    // Start is called before the first frame update
    void Start()
    {
        scripts = GameObject.Find("Scripts");
        worldControl = scripts.GetComponent<Start_World>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick(){
        worldControl.checkAnswer(correctanswer);
	}
}
