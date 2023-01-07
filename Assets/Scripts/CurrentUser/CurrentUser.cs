using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUser : MonoBehaviour
{
    public static CurrentUser Instance;
    //{ get; private set; }
    private API_calls api;
    public UserModel user;
    public StationModel currentStation;

    void Start()
    {
        api = gameObject.GetComponent<API_calls>();
        getCurrentUser();
        setUser(1);
        setCurrentStation(9);
       }
  
    private CurrentUser()
    {

    } 

    public static CurrentUser getCurrentUser() {
        if (Instance == null) { 
            Instance = new CurrentUser();
        }
        return Instance;
    }


    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    async void setUser(int id)
    {
        user = await api.getUser(id);
        Debug.Log(user);
    }

    public UserModel getUser()
    {
        return user;
    }

    async public void setCurrentStation(int id) {
        currentStation = await api.getStation(id);
        List<int> oldList = user.stationsVisited;
        List<int> newList = new List<int>();
        if (oldList == null ) {
            newList.Add(id);
        }
        else  if (!oldList.Contains(id))
        {
            newList = oldList; 
            newList.Add(id);

        }
        user.stationsVisited = newList;
        await api.updateUser(user);

    }

    public StationModel getCurrentStation()
    {
        return currentStation;
    }

    //getcurrentstation
    public int getCurrentStationID()
    {
        return 9;
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

}
