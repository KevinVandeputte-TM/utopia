using System;
using System.Collections.Generic;


[Serializable]
public class UserModel
{
    public int userID { get; set; }
    public string name { get; set; }
    public object interest { get; set; }
    public int birthyear { get; set; }
    public int score { get; set; }
    public object stationsVisited { get; set; }

}
[Serializable]
public class StationModel
{
    public int stationID { get; set; }
    public string education { get; set; }
    public string faculty { get; set; }
    public string information { get; set; }
    public List<QuestionModel> questions { get; set; }

}
[Serializable]
public class QuestionModel
{
    public int questionID { get; set; }
    public object questiontoask { get; set; }
    public string correctanswer { get; set; }
    public string fOne { get; set; }
    public string fTwo { get; set; }
    public string fThree { get; set; }
    public object station { get; set; }
}
