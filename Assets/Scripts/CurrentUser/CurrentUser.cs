using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUser : MonoBehaviour
{
    public static CurrentUser Instance;
    private API_calls api;
    private UserModel user;
    private StationModel currentStation;
    private int score;
    private int startStationID;

    //when start of scene get the current user
    //for testing set default user, currentstation and startstationID
    void Start()
    {
        api = gameObject.GetComponent<API_calls>();
        getCurrentUser();
        setUser(1);
        setCurrentStation(1000);
        setStartStationID(1011);
    }

    private CurrentUser()
    {

    } 

    // create the current user
    public static CurrentUser getCurrentUser() {
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
    async public void setUser(int id)
    {
        user = await api.getUser(id);
        Debug.Log(user);
    }

    // get logged in user
    public UserModel getUser()
    {
        return user;
    }

    //set the station currently visited + add visited station to the list
    async public void setCurrentStation(int id) {
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
    public StationModel getCurrentStation()
    {
        return currentStation;
    }

    //get currentstation ID
    public int getCurrentStationID()
    {
        return currentStation.stationID;
    }

    //getScore
    public int getScore()
    {
        return user.score;
    }

    //update score
    async public void setScore ()
    {
        this.user.score += 1 ;
        await api.updateUser(this.user);
    }

    //set StartStation for metro in metroNetwork
    public void setStartStationID(int id)
    {
        startStationID = id;

    }

    public int getStartStationID()
    {
        return startStationID;
    }


}
