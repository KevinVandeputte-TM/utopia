using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
				Debug.Log("This is fired: now we navigate!" );
				
				switch (thisIndex)
                {
					case 0:
						break;
					case 1:
						LoadScene(1);
						break;
					case 2:
						break;
					default:
						break;
                }
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }

	void LoadScene(int SceneIndex)
    {
		SceneManager.LoadScene(SceneIndex);
    }
}
