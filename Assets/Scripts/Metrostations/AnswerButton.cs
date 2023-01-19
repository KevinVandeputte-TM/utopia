
using UnityEngine;


public class AnswerButton : MonoBehaviour
{
    [SerializeField] AnswerButtonController answerButtonController;
    [SerializeField] Animator animator;
	[SerializeField] AnswerButtonAnimatorFunctions answerAnimatorFunctions;
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
        answerAnimatorFunctions = this.GetComponent<AnswerButtonAnimatorFunctions>();

        if(thisIndex == 0){
            answerAnimatorFunctions.disableOnce = true;
        }      
    }

    // Update is called once per frame
    void Update()
    {
        //Check f the index of the button is the same of the selected index of de button controller
        if(thisIndex == answerButtonController.index )
        {
            //if index is same as controller index play selected animation
            animator.SetBool("selected", true);

            //When hit submit execute animation
            if(Input.GetAxis ("Submit") == 1 && correctanswer){
                animator.SetBool("pressed", true);
                animator.SetBool("correct", true);

            // to avoid multiple firing of TaskOnClick
            // if pressed then set to false and execute TaskOnClick
            }else if(Input.GetAxis ("Submit") == 1 && !correctanswer){
                animator.SetBool("pressed", true);
                animator.SetBool("wrong", true);

            }else if (animator.GetBool ("pressed")){
				animator.SetBool("pressed", false);
				answerAnimatorFunctions.disableOnce = true;
                TaskOnClick();
            }
        } else {
            animator.SetBool("selected", false);
        }
    }

    public void TaskOnClick(){
        worldControl.checkAnswer(correctanswer);
	}
}
