using System;
using System.Collections.Generic;


[Serializable]
public class UserModel
{
    public int userID { get; set; }
    public string name { get; set; }
    public int interestID { get; set; }
    public int birthyear { get; set; }
    public int score { get; set; }
  public List<int> stationsVisited { get; set; }

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
    public string question { get; set; }
    public string correctanswer { get; set; }
    public string fOne { get; set; }
    public string fTwo { get; set; }
    public string fThree { get; set; }
    public StationModel station { get; set; }
}

[Serializable]
public class InterestModel
{
    public int id { get; set; }
    public int interestID { get; set; }
    public string interestname { get; set; }
   
    public List< StationModel> stations { get; set; }
}