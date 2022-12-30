using System.Collections.Generic;

[System.Serializable]
public class UserModel
{
    public int userID;
    public string name;
    public int birthYear;
    public string interest;
    public double score;

    //FK - one to Many side
    public List<VisitedModel> stationsVisited;

}
