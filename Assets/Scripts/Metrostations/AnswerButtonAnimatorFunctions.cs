using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonAnimatorFunctions : MonoBehaviour
{

    
    [SerializeField] AnswerButtonController answerButtonController;
	public bool disableOnce;
    // Start is called before the first frame update
    void Start()
    {
        answerButtonController = GameObject.Find("/UI_question/Canvas/Questionbox/Answerbuttons").GetComponent<AnswerButtonController>();
    }

    void PlaySound(AudioClip whichSound){
        if(!disableOnce){
			answerButtonController.audioSource.PlayOneShot (whichSound);
		}else{
			disableOnce = false;
		}
	}


}
