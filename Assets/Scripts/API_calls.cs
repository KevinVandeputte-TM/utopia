using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

using Newtonsoft.Json;
using UnityEditor.Networking;
using UnityEngine.Networking;
using TMPro;
using System.Threading.Tasks;
using System;

public class API_calls : MonoBehaviour
{
    //highscores

    public async void GetHighscores()
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/highscores/";

        var result = await apiHandler.Get < List < UserModel >>(url);

    }

    //stations
    [ContextMenu("Gethighscores")]
    public async void GetStations()
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/stations/" ;

        var result = await apiHandler.Get<List<StationModel>>(url);

    }
    //questions/station_id
    public async void GetQuestionsByStation(int stationID)
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/questions/" + stationID;

        var result = await apiHandler.Get < List < QuestionModel >>(url);

    }

    //station/station_id
    public async void getStation(int stationID)
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/station/" + stationID;

        var result = await apiHandler.Get<StationModel>(url);

    }

    //users
    public async void getUsers()
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/users/" ;

        var result = await apiHandler.Get < List < UserModel >>(url);

    }

    //users/user_id
    public async void getUser(int userID)
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/users/" + userID;

        var result = await apiHandler.Get<UserModel>(url);

    }

}