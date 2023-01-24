using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// metro-object: Sci Fi Train by FiveBrosStopMosYT licensed under CC-BY 4.0.

public class MetroController : MonoBehaviour
{
    private GameObject instance;
    API_calls api;
    CurrentUser currentUser;
    public bool canMove;


    // Start is called before the first frame update
    void Start()
    {
        api = GameObject.Find("Scripts").GetComponent<API_calls>();
        //GetMetro();

        //get start station from currentUser
        currentUser = CurrentUser.GetCurrentUser();
        int startposition = currentUser.GetStartStationID();
        StartPosition(startposition);
        canMove = true;
    }

    //get Metro, if not existing create new object
    public GameObject GetMetro()
    {
        if (instance == null)
        {
            instance = gameObject;
        }
        return instance;
    }

    //get startposition metro from id 
    async void StartPosition(int id)
    {
        StationModel station = await api.getStation(id);
        string stationName = station.education.ToString();

        // get position from station
        Vector2 position = transform.position;
        Vector2 newPosition = GameObject.Find(stationName).transform.position;

        //transform: set metroposition to position station
        transform.position = newPosition;
    }
}
