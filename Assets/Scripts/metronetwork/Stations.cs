using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;


public class Stations : MonoBehaviour
{
    public List<StationModel> stations;
    API_calls api;
    public StationModel station;
    private CurrentUser currentUser;



    void Start()
    {
        currentUser = CurrentUser.GetCurrentUser();
        stations = currentUser.GetStations();
    }

  

    public StationModel GetStation(int id)
    {

        Debug.Log("in getstation" + stations.Count);


        //var result = stations.FirstOrDefault(station => station.stationID == 1000);
        /* for(int i = 0; i < stations.Count; i++)
         {
             if(stations[i].stationID == id)
             {
                 result = stations[i];
                 return result;
             }
         }
        */
        //return result;
        return stations[0];

    }
   
}
