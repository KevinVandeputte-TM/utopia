using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] AnswerButtonController answerButtonController;
    public bool correctanswer;
    GameObject scripts;
    Start_World worldControl;
    public int thisIndex;

    // Start is called before the first frame update
    void Start()
    {
        scripts = GameObject.Find("Scripts");
        worldControl = scripts.GetComponent<Start_World>();
        //connect the AnswerButtonController when loading the button
        answerButtonController = GameObject.Find("/UI_question/Canvas/Questionbox/Answerbuttons").GetComponent<AnswerButtonController>();      
    }

    // Update is called once per frame
    void Update()
    {
        //Check f the index of the button is the same of the selected index of de button controller
        if(thisIndex == answerButtonController.index ){
            //When hit submit excute TaskOnClick
            if(Input.GetAxis ("Submit") == 1){
                TaskOnClick();
            }
        }
        
    }

    public void TaskOnClick(){
        worldControl.checkAnswer(correctanswer);
	}
}
