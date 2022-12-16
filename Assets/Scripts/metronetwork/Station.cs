using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Station : MonoBehaviour{
      [Header("Level Info")]
	public string stationName;
	public string metroLine;

	[Header("Node Destinations")]
	public GameObject upDestination;
	public GameObject downDestination;
	public GameObject leftDestination;
	public GameObject rightDestination;
	
	[Header("Dependencies")]
	public GameObject metro;
	public bool isAvailable;
	private bool currentStation;
	public Text stationNameText;
	public Text metroLineText;
	private bool stationPlayed;
	
	private bool staticMap;

    // Start is called before the first frame update
    void Start()
    {
	if (GetComponent <SpriteRenderer> () != null) {
			GetComponent <SpriteRenderer> ().enabled = false;
		}

        
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position == metro.transform.position) {
			currentStation= true;
			if (!stationPlayed) {
				stationPlayed = true;
			}
		} else {
			currentStation= false;
			stationPlayed = false;
		}

		if (currentStation) {
			stationNameText.text = stationName;
			metroLineText.text = metroLine;

				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					if (upDestination != null) {
						if (upDestination.activeInHierarchy) {
							currentStation = false;
							StartCoroutine (DoUp ()); 
						}
					}
				} else {
					if (Input.GetKeyDown (KeyCode.DownArrow)) {
						if (downDestination != null) {
							if (downDestination.activeInHierarchy) {
								currentStation = false;
								StartCoroutine (DoDown ()); 
							}
						}
					} else {
						if (Input.GetKeyDown (KeyCode.LeftArrow)) {
							if (leftDestination != null) {
								if (leftDestination.activeInHierarchy) {
									currentStation = false;
									StartCoroutine (DoLeft ()); 
								}
							}
						} else {
							if (Input.GetKeyDown (KeyCode.RightArrow)) {
								if (rightDestination != null) {
									if (rightDestination.activeInHierarchy) {
										currentStation = false;
										StartCoroutine (DoRight ()); 
									}
								}
							}
						}
					}
				}
			}

	}
	IEnumerator DoUp()
	{
		yield return new WaitForSeconds (1/60);
		while (metro.transform.position != upDestination.transform.position)
		{
			metro.transform.position = Vector3.MoveTowards(metro.transform.position, upDestination.transform.position, 8f * Time.deltaTime);
			yield return null;
		}
	}
	IEnumerator DoDown()
	{
		yield return new WaitForSeconds (1/60);
		while (metro.transform.position != downDestination.transform.position) {
			metro.transform.position = Vector3.MoveTowards (metro.transform.position, downDestination.transform.position, 8f * Time.deltaTime);
			yield return null;
		}
	}
	IEnumerator DoLeft()
	{
		yield return new WaitForSeconds (1/60);
		while (metro.transform.position != leftDestination.transform.position) {
			metro.transform.position = Vector3.MoveTowards (metro.transform.position, leftDestination.transform.position, 8f * Time.deltaTime);
			yield return null;
		}
	}
	IEnumerator DoRight()
	{	
		yield return new WaitForSeconds (1/60);
		while (metro.transform.position != rightDestination.transform.position) {
			metro.transform.position = Vector3.MoveTowards (metro.transform.position, rightDestination.transform.position, 8f * Time.deltaTime);
			yield return null;
		}
		
	}
}
