using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StationController : MonoBehaviour
{
	[Header("Level Info")]
	public int stationID;
	private string stationName;
	private StationModel station;
	private string metroLine;

	[Header("If there is a world available, check this:")]
	public bool isAvailable;
	private bool isVisited;
	public int world;

	[Header("Metro Destinations")]
	public GameObject leftDestination;
	public GameObject upDestination;
	public GameObject rightDestination;
	public GameObject downDestination;


	[Header("Dependencies")]
	public TextMeshProUGUI stationText;
	public TextMeshProUGUI MetroLineText;
	private bool isCurrentStation;
	private API_calls api;
	private Stations stations;
	private Transition transition;
	private CurrentUser currentUser;
	private GameObject metro;
	MetroController metroController;



	// Start is called before the first frame update
	void Start()
	{
		//api = GameObject.Find("Scripts").GetComponent<API_calls>();
		stations = GameObject.Find("Scripts").GetComponent<Stations>();
		metroController = GameObject.Find("Metro").GetComponent<MetroController>();
		currentUser = CurrentUser.GetCurrentUser();
		metro = GameObject.Find("/Metro");
		stationName = "halte";
		metroLine = gameObject.tag;

		//gameObject.SetActive(false);


		if (stationID != 0)
		{
			//station = await api.getStation(stationID);

			//gameObject.SetActive(true);
			station = stations.GetStation(1000);
		

			if (station != null)
			{
				stationName = station.education.ToString();
				gameObject.name = stationName;

				if (isAvailable)
				{
					gameObject.GetComponent<Renderer>().material.color = new Color(73 / 250f, 160 / 250f, 118 / 250f);
					Vector3 objectScale = transform.localScale;
					transform.localScale = new Vector3(objectScale.x * 1.5f, objectScale.y * 1.5f, objectScale.z * 1.5f);
				}
			}
			else
			{
				stationName = "halte";
			}
		}
		


	}


	// Update is called once per frame
	void Update()
	{
		
			if (isVisited)
			{
				gameObject.GetComponent<Renderer>().material.color = new Color(0, 250, 0);

			}

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
			
				stationText.text = stationName.ToUpper();
				MetroLineText.text = metroLine;
			

				if (metroController.canMove)
				{

					if (Input.GetAxis("Vertical") > 0 & (upDestination != null))
					{
						isCurrentStation = false;
						StartCoroutine(Movemetro(upDestination));
						StartCoroutine(MetroVertical());
					}

					else if (Input.GetAxis("Horizontal") > 0 && (rightDestination != null))
					{
						isCurrentStation = false;
						StartCoroutine(Movemetro(rightDestination));
						StartCoroutine(MetroHorizontal());

					}
					else if (Input.GetAxis("Vertical") < 0 && (downDestination != null))
					{
						isCurrentStation = false;
						StartCoroutine(Movemetro(downDestination));
						StartCoroutine(MetroVertical());
					}
					else if (Input.GetAxis("Horizontal") < 0 && (leftDestination != null))
					{
						isCurrentStation = false;
						StartCoroutine(Movemetro(leftDestination));
						StartCoroutine(MetroHorizontal());
					}



					if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) && isAvailable && (world != 0))
					{
						currentUser.SetCurrentStation(stationID);
						currentUser.SetStartStationID(stationID);
						transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
						transition.LoadLevel(world);

					}
				}
		}

	}

	IEnumerator Movemetro(GameObject destinationvariable)
	{
		Vector3 targetPosition = transform.position;
		targetPosition = destinationvariable.transform.position;
		yield return new WaitForSeconds(1 / 60);
		while (metro.transform.position != targetPosition)
		{
			metro.transform.position = Vector3.MoveTowards(metro.transform.position, targetPosition, 5f * Time.deltaTime);
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

	/*float HexToFloat(string hex)
    {
		float result = System.Convert.ToInt32(hex, 16) / 255f;
		return result ;
    }

	private Color GetColorFromString(string hex)
    {
		float red = HexToFloat(hex.substring(0, 2));
		float green = HexToFloat(hex.substring(2, 4));
		float blue = HexToFloat(hex.substring(4, 6));

		return new Color();
	
	}*/



}
