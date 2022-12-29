using System;
using System.Collections.Generic;

[System.Serializable]
public class VisitedModel
{
    public int visitedID;
    public string interest;
    public DateTime timestamp;


    //FK - many to one side
    public int stationID;
    public StationModel station;
    public int userID;
    public UserModel user;
}
