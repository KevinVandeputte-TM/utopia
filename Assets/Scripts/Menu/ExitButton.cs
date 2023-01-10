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
    LeaveWorld leaveworld; 

    void Start()
    {
        leaveworld = gameObject.GetComponent<LeaveWorld>();
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

             leaveworld.onUserClickYesNo(thisIndex);
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }

    }
}
