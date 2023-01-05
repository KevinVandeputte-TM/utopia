using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUser : MonoBehaviour
{
    public static CurrentUser Instance;
    //{ get; private set; }
    public UserModel user;

    public StationModel currentStation;

    private API_calls api;
    async void Start()
    {
        api = gameObject.GetComponent<API_calls>();
        currentStation = await api.getStation(9);
        user = await api.getUser(1);

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

    async void setCurrentUser(int id)
    {
        user = await api.getUser(id);

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

    public int getScore()
    {
        return user.score;
    }

    async public void setScore (int points)
    {
        await api.updateUser(user.userID, user.score + points);
    }

}
