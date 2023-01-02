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
using System.Linq;
using System.ComponentModel;
using Unity.VisualScripting;

public class API_calls : MonoBehaviour
{
    API_handler apiHandler = new API_handler();
    string urlbase = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/";

    //highscores

    public  Task<List<UserModel>> GetHighscores()
    {
        var url = urlbase+"highscores/";
        var result =  apiHandler.Get<List<UserModel>>(url);
            return result;
    }

  
    //stations
    public Task<List<StationModel>> GetStations()
    {
        var url = urlbase + "stations/";
        var result = apiHandler.Get<List<StationModel>>(url);
        return result;

    }
    //questions/station_id
    public Task<List<QuestionModel>> GetQuestionsByStation(int stationID)
    {
        var url = urlbase + "questions/" + stationID;
        var result =apiHandler.Get<List<QuestionModel>>(url);
        return result;
    }

    //station/station_id
    public Task<StationModel> getStation(int stationID)
    {
        var apiHandler = new API_handler();
        var url = urlbase + "station/" + stationID;
        var result =  apiHandler.Get<StationModel>(url);
        return result;
    }

    //users
    public Task<List<UserModel>>getUsers()
    {
  
        var url = urlbase + "users/";
        var result =  apiHandler.Get<List<UserModel>>(url);
        return result;

    }

    //users/user_id
    public Task<UserModel> getUser(int userID)
    {
        var url = urlbase + "users/" + userID;
        var result = apiHandler.Get<UserModel>(url);
        return result;
    }

}









