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
	private Transition transition;
	private CurrentUser currentUser;
	private GameObject metro;
	MetroController metroController;
	private GameObject metroLineObject;

	//colors for metrolines
	private string[,] ColorArray = new string[8, 2] {
		{ "Business and Tourism","E9B723"},
		{ "Sport", "67C0EE"},
		{ "Design and Build","1D1D1B"},
		{"People and Health","AEB429"},
		{"Tech and IT", "384F8D" },
		{"Life Sciences and Chemistry", "4A975C" },
		{ "Education", "962373"},
		{ "Media and Communication", "DF739C"}
	};

	void Start()
	{
		metroController = GameObject.Find("Metro").GetComponent<MetroController>();
		metroLineObject = GameObject.Find("MetroLine");
		currentUser = CurrentUser.GetCurrentUser();
		metro = GameObject.Find("/Metro");
		stationName = "halte";
		metroLine = gameObject.tag;

		// check if stationID
		if (stationID != 0)
		{
			//get Station from stationID;
			station = currentUser.GetStationByID(stationID);

			// check if station is loaded
			if (station != null)
			{
				//set stationname in game + stationname for object
				stationName = station.education.ToString();
				gameObject.name = stationName;

				//when station is available: set scale + color
				if (isAvailable)
				{
					gameObject.GetComponent<Renderer>().material.color = new Color(73 / 250f, 160 / 250f, 118 / 250f);
					Vector3 objectScale = transform.localScale;
					transform.localScale = new Vector3(objectScale.x * 1.5f, objectScale.y * 1.5f, objectScale.z * 1.5f);
				}
			}
			//when there is no station, set name as "halte"
			else
			{
				stationName = "halte";
			}
		}	
	}

	void Update()
	{	
		//when metro has same position as station. Station = currentStation
		if (metro.transform.position == transform.position)
		{
			isCurrentStation = true;
		}
		else
		{
			isCurrentStation = false;
		}

		//set metro active 
		metro.SetActive(true);

		//set name station and metroLinetext in scene 
		if (isCurrentStation)
		{
			stationText.text = stationName.ToUpper();
			MetroLineText.text = metroLine;
			metroLineObject.GetComponent<Image>().color = GetColorFromGameTag(metroLine);
			
			if (metroController.canMove)
			{
				// move up
				if (Input.GetAxis("Vertical") > 0 & (upDestination != null))
				{
					isCurrentStation = false;
					StartCoroutine(Movemetro(upDestination));
					StartCoroutine(MetroVertical());
				}

				// move right
				else if (Input.GetAxis("Horizontal") > 0 && (rightDestination != null))
				{
					isCurrentStation = false;
					StartCoroutine(Movemetro(rightDestination));
					StartCoroutine(MetroHorizontal());
				}

				//move down
				else if (Input.GetAxis("Vertical") < 0 && (downDestination != null))
				{
					isCurrentStation = false;
					StartCoroutine(Movemetro(downDestination));
					StartCoroutine(MetroVertical());
				}

				//move left
				else if (Input.GetAxis("Horizontal") < 0 && (leftDestination != null))
				{
					isCurrentStation = false;
					StartCoroutine(Movemetro(leftDestination));
					StartCoroutine(MetroHorizontal());
				}

				//enter world on enter-press
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

	//function to move metro toward next station
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

	//set metroposition vertical
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

	//set metroposition horizontal
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


	//set hex to normalized float
	float HexToFloat(string hex)
    {
		float result = System.Convert.ToInt32(hex, 16) / 255f;
		return result ;
    }

	//get color for gametag
	private Color GetColorFromString(string hex)
    {
		float red = HexToFloat(hex.Substring(0, 2));
		float green = HexToFloat(hex.Substring(2, 2));
		float blue = HexToFloat(hex.Substring(4, 2));

		return new Color(red, green, blue, 1f);

    }

	//get color in float when given gametag
	private Color GetColorFromGameTag(string gametag)
    {
		string hex="";
			for (int i = 0; i < ColorArray.GetLength(0); i++)
			{
				if (ColorArray[i , 0] == gametag)
				{
					hex= ColorArray[i,1];
				}
			}
		return GetColorFromString(hex);		
	}
}
