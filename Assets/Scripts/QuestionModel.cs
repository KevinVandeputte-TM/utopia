using System.Collections.Generic;

[System.Serializable]
public class QuestionModel
{
    public int questionID;
    public string question;
    public string answerCorrect;
    public string fOne;
    public string fTwo;
    public string fThree;
    public string fFour;

    //FK - many to one side
    public int stationID;
    public StationModel station;
}
