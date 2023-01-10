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
	public GameObject metro;
	public TextMeshProUGUI stationText;
	public TextMeshProUGUI MetroLineText;
	private bool isCurrentStation;
	private API_calls api;
	private Transition transition;
	private CurrentUser currentUser;
	MetroController metroController;



	// Start is called before the first frame update
	async void Start()
	{
		api = GameObject.Find("Scripts").GetComponent<API_calls>();
		currentUser = CurrentUser.getCurrentUser();


		if (stationID != 0)
		{
			station = await api.getStation(stationID);
			stationName = station.education.ToString();
			gameObject.name = stationName;

			if (isAvailable)
			{
				gameObject.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
			}
		}

		else
		{
			stationName = "tussenstop";
		}

		metroLine = gameObject.tag;


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
			stationText.text = stationName;
			MetroLineText.text = metroLine;

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
				currentUser.setCurrentStation(stationID);
				currentUser.setStartStationID(stationID);
				Debug.Log("set stationID" + stationID);
				Debug.Log("gezet: " + currentUser.getStartStationID());
				transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
				transition.LoadLevel(world);

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



}
