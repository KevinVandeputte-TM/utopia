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
				
				switch (sceneToNavigateTo)
                {
					case "Home":
                        LoadScene(0);
                        break;
					case "About":
						LoadScene(1);
						break;
					case "Highscores":
                        LoadScene(2);
                        break;
                    case "Start":
						databaseManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<DatabaseManager>();

						databaseManager.CreateUser(3);
                        break;
                    case "Metronetwork":
                        LoadScene(4);
                        break;
                    case "Metrostation":
                        LoadScene(5);
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
