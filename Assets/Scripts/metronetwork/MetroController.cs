using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sci Fi Train by FiveBrosStopMosYT licensed under CC-BY 4.0.

public class MetroController : MonoBehaviour
{
    private static GameObject instance;


    // Start is called before the first frame update
    void Start()
    {
        PositionFromInterestId(21);
 
        
    }

    // Update is called once per frame
 void Update()
   {

   }

 async void PositionFromInterestId(int id) {
        //get metroId
        //int metrofrominterestId = 1;
        //get stationName
        API_calls api = GameObject.Find("_SM").GetComponent<API_calls>();
        StationModel station = await api.getStation(id);
        Debug.Log(station);
        string stationName = station.education.ToString();

        // get position from station
        Vector2 position = transform.position;
        Vector2 newPosition = GameObject.Find(stationName).transform.position;       
        transform.position = newPosition;
    }


    void Awake()
    {

        DontDestroyOnLoad(transform.gameObject);

        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
