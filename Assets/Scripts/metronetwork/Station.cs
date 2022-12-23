using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Station : MonoBehaviour
{
	[Header("Level Info")]
	public string stationName;
	public string metroLine;

	[Header("If there is a world available, check this:")]
	public bool isAvailable;
	public string world;

	[Header("Metro Destinations")]
	public GameObject leftDestination;
	public GameObject upDestination;
	public GameObject rightDestination;
	public GameObject downDestination;


	[Header("Dependencies")]
	public GameObject metro;
	public TextMeshProUGUI stationText;
	public TextMeshProUGUI MetroLineText;



	private bool isCurrentStation;



	// Start is called before the first frame update
	void Start()
	{

	}

		
	// Update is called once per frame
	void Update()
	{
			if (metro.transform.position == transform.position)
			{
				isCurrentStation = true;
			}
        else
        {
			isCurrentStation = false;
        }
			metro.SetActive(true);


		if (isCurrentStation)
		{
			stationText.text = stationName;
			MetroLineText.text = metroLine;
		
			if (Input.GetKeyDown("up") && (upDestination != null))
			{				
				isCurrentStation = false;
				StartCoroutine(Movemetro(upDestination));
				StartCoroutine(MetroVertical());
			}

			else if (Input.GetKeyDown("right") && (rightDestination != null))
			{
				isCurrentStation = false;
				StartCoroutine(Movemetro(rightDestination));
				StartCoroutine(MetroHorizontal());

			}
			else if (Input.GetKeyDown("down") && (downDestination != null))
			{
				isCurrentStation = false;
				StartCoroutine(Movemetro(downDestination));
				StartCoroutine(MetroVertical());
			}
			else if (Input.GetKeyDown("left") && (leftDestination != null))
			{
				isCurrentStation = false;
				StartCoroutine(Movemetro(leftDestination));
				StartCoroutine(MetroHorizontal());
			}

			if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) && isAvailable && (world!= null))
            {
				Debug.Log("enter world");
				SceneManager.LoadScene(world);
            }
			
		}

	}

	IEnumerator Movemetro(GameObject destinationvariable) {
		Vector3 targetPosition = transform.position;
		targetPosition = destinationvariable.transform.position;
		yield return new WaitForSeconds(1 / 60);
		while (metro.transform.position != targetPosition) {
			metro.transform.position = Vector3.MoveTowards(metro.transform.position, targetPosition, 10f * Time.deltaTime);
			yield return null;
		} 
	
	}

	IEnumerator MetroVertical()
	{
		Vector3 positionVertical = new Vector3(0, 0, 90);
		yield return new WaitForSeconds(1 / 60);
		if (metro.transform.eulerAngles.z != 90)
		{
			metro.transform.Rotate(positionVertical);
			yield return null;
		}

	}


	IEnumerator MetroHorizontal()
	{
		Vector3 positionHorizontal = new Vector3(0, 0, -90);
		yield return new WaitForSeconds(1 / 60);
		if (metro.transform.eulerAngles.z != 0)
		{
			metro.transform.Rotate(positionHorizontal);
			yield return null;
		}

	}


}