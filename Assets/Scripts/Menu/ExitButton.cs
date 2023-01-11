using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    private Transition transition;
    public bool player;
    public bool metro;
    public int indexToNavigateTo;
    LeaveWorld leaveworld; 

    void Start()
    {
        if(player)
        {
            leaveworld = GameObject.Find("Astronaut").GetComponent<LeaveWorld>();

        }
        else
        {
            leaveworld = GameObject.Find("Scripts").GetComponent<LeaveWorld>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
                leaveworld.onUserClickYesNo(thisIndex, indexToNavigateTo );
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }

    }
}
