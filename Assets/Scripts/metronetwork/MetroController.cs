using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sci Fi Train by FiveBrosStopMosYT licensed under CC-BY 4.0.

public class MetroController : MonoBehaviour
{
    private GameObject instance;
    API_calls api;
    CurrentUser currentUser;


    // Start is called before the first frame update
    void Start()
    {
        api = GameObject.Find("Scripts").GetComponent<API_calls>();
        getMetro();

        //get start station from currentUser
        currentUser = CurrentUser.getCurrentUser();
        int startposition = currentUser.getStartStationID();
        startPosition(currentUser.getStartStationID());

    }


    //get Metro, if not existing create new object
    public GameObject getMetro()
    {
        if (instance == null)
        {
            instance = gameObject;
        }
        return instance;
    }

    //get startposition metro from id 
    async void startPosition(int id)
    {
        Debug.Log("in startposition met id " + id);

        StationModel station = await api.getStation(id);
        string stationName = station.education.ToString();

        // get position from station
        Vector2 position = transform.position;
        Vector2 newPosition = GameObject.Find(stationName).transform.position;

        //transform
        transform.position = newPosition;
    }



}
