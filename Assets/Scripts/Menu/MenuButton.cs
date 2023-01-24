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
    [SerializeField] string sceneToNavigateTo;

	DatabaseManager databaseManager;

    
    private Transition transition;

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
				
				switch (sceneToNavigateTo)
                {
					case "Home":
                        LoadScene(2);
                        break;
					case "About":
						LoadScene(3);
						break;
					case "Highscores":
                        LoadScene(4);
                        break;
                    case "Login":
                        LoadScene(5);
                        break;
                    case "Metronetwork":
                        LoadScene(7);
                        break;
                    case "Metrostation":
                        LoadScene(7);
                        break;
                    case "Intro":
                        LoadScene(1);
                        break;
					case "StartGame":
                        databaseManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<DatabaseManager>();

                        databaseManager.CreateUser(6);
                     
                        break;
                    default:
						break;
                }
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }

	void LoadScene(int sceneIndex)
    {
        transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
        transition.LoadLevel(sceneIndex);
    }


}
