using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CurrentUser : MonoBehaviour
{
    public static CurrentUser Instance;
    private API_calls api;
    private UserModel user;
    private StationModel currentStation;
    private int score;
    private int startStationID;
    private List<StationModel> stations;


    //when start of scene get the current user
    //for testing set default user, currentstation and startstationID
    async void Start()
    {
        api = gameObject.GetComponent<API_calls>();
        GetCurrentUser();
        SetUser(1);
        SetCurrentStation(1000);
        SetStartStationID(1011);
        SetStations();
    }

    private CurrentUser()
    {

    } 

    // create the current user
    public static CurrentUser GetCurrentUser() {
        if (Instance == null) { 
            Instance = new CurrentUser();
        }
        return Instance;
    }

    //don't destroy user when leaving scene
    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //set the user to the user logged in
    public async void SetUser(int id)
    {
        user = await api.getUser(id);
    }

    // get logged in user
    public UserModel GetUser()
    {
        return user;
    }

    //set the station currently visited + add visited station to the list
    public async void SetCurrentStation(int id) {
        //id>0: add visited station to list 
        if (id > 0)
        {
            currentStation = await api.getStation(id);
            List<int> oldList = user.stationsVisited;
            List<int> newList = new List<int>();
            if (oldList == null || oldList.Count == 0)
            {
                newList.Add(id);
            }
            else if (!oldList.Contains(id))
            {
                newList = oldList;
                newList.Add(id);

            }
            user.stationsVisited = newList;
            await api.updateUser(user);
        }
        //id = 0, reset current station 
        else
        {
            currentStation = null;
        }

    }

    //get the station currently visiting
    public StationModel GetCurrentStation()
    {
        return currentStation;
    }

    //get the station by ID
    public StationModel GetStationByID(int ID)
    {
        return stations.FirstOrDefault(station => station.stationID == ID);
    }

    //get currentstation ID
    public int GetCurrentStationID()
    {
        return currentStation.stationID;
    }



    //getScore
    public int GetScore()
    {
        return user.score;
    }

    //update score
    public async void SetScore ()
    {
        this.user.score += 1 ;
        await api.updateUser(this.user);
    }

    //set StartStation for metro in metroNetwork
    public void SetStartStationID(int id)
    {
        startStationID = id;

    }

    public int GetStartStationID()
    {
        return startStationID;
    }


    async void SetStations() {
        stations = await api.GetStations();
    }

    public List<StationModel> GetStations()
    {
        if(stations.Count == 0)
        {
            SetStations();

        }
        return stations;
    }


}
