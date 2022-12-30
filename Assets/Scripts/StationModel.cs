using System.Collections.Generic;

[System.Serializable]
public class StationModel
{
    public int stationID;
    public string education;
    public string faculty;
    public string information;

    //FK - one to Many side
    public List<QuestionModel> questions;
    public List<VisitedModel> visited;
}
