using System.Collections.Generic;

using UnityEngine;


using System.Threading.Tasks;


public class API_calls : MonoBehaviour
{
    API_handler apiHandler = new API_handler();
    string urlbase = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/";

    //highscores
        public  Task<List<UserModel>> GetHighscores()
    {
        var url = urlbase+"highscores";
        var result =  apiHandler.Get<List<UserModel>>(url);
            return result;
    }

      //stations
    public Task<List<StationModel>> GetStations()
    {
        var url = urlbase + "stations";
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
  
        var url = urlbase + "users";
        var result =  apiHandler.Get<List<UserModel>>(url);
        return result;

    }

    //user/user_id
    public Task<UserModel> getUser(int userID)
    {
        var url = urlbase + "users/" + userID;
        var result = apiHandler.Get<UserModel>(url);
        return result;
    }


    //PUT user = > given the user
    public Task updateUser(UserModel user)
    { 
        //start the put request
        var url = urlbase + "user";
        var result = apiHandler.Put(url, user);
        return result;
    }

    //POST = > users/user_id
    public Task<UserModel> addUser(string name, int birthyear, int interestID)
    {
        //get the user
        UserModel user = new UserModel();
        user.name = name;
        user.birthyear = birthyear;
        user.interestID = interestID;
        user.score = 0;

        //start the put request
        var url = urlbase + "user";
        var result = apiHandler.Post<UserModel>(url, user);
        return result;
    }
    //add visited station to visited point 
    public Task addVisit(int stationID, int interestID) {
        var url = urlbase + "visit?stationID=" + stationID + "&interestID=" + interestID;
        var result = apiHandler.PostVisit(url);
        return result;
    }

    //get startstation when given interestID
    public Task<StationModel> getStartStation(int interestID)
    {
        if (interestID == 9)
        {
           interestID = 1;
        }
        var url = urlbase + "startstation/" + interestID;
        var result = apiHandler.Get<StationModel>(url);
         return result;

    }


}









