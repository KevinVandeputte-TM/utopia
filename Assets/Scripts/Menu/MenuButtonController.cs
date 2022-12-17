using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	public bool vertical = true;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// get the verical input
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
				} else if(keyInput > 0){
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
