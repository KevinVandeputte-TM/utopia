using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonController : MonoBehaviour
{

    public int index;
	public bool vertical = true;
	[SerializeField] bool keyDown;
	public int maxIndex;
	public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        // get the input
		float keyInput = vertical ? Input.GetAxis("Vertical") : Input.GetAxis("Horizontal");
		if (keyInput != 0){
			// only trigger on keydown, not on key down hold
			if(!keyDown){
				// update the index
				if (keyInput < 0) {
					if(index < maxIndex){
						index++;
					}else{
						index = 0;
					}
				} else if(keyInput > 0) {
					if(index > 0){
						index --; 
					}else{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		// set keydown to false for next triggering
		}else{
			keyDown = false;
		}
        
    }
}
