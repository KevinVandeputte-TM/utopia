using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(API_calls))]
public class Highscore : MonoBehaviour
{

    API_calls sn;


     async void Start()
    {
        //elements to be transformed
        Transform titletable = transform.Find("TableTitles");
        Transform loadingtext = transform.Find("LOADING");
        Transform entryContainer= transform.Find("highscoreEntryContainer");
     Transform entryTemplate= entryContainer.Find("entryTemplate");

        //start state
        titletable.gameObject.SetActive(false);
        loadingtext.gameObject.SetActive(true);

        //get API SCRIPT OBJECT
        sn = gameObject.GetComponent<API_calls>();

//api call
      var highscoreList= await sn.GetHighscores();

        //hide loading text 
        if (highscoreList != null)
        {
            //hide loading text
          loadingtext.gameObject.SetActive(false);
            //show tabletitles
            titletable.gameObject.SetActive(true);
        }

        //make copies and fill in the text
        float templateHeight = 100f;

        entryTemplate.gameObject.SetActive(false);


        for (int i=0; i < 10; i++)
        {
            //duplicate the parent
            Transform entryTransform = Instantiate(entryTemplate,entryContainer);
            RectTransform rectRectTransform = entryTransform.GetComponent<RectTransform>();
            rectRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);

            //edit text
            //Text_Highscore Number
            Transform textNumber= entryTransform.GetChild(0);
            Text textNumberT = textNumber.GetComponent<Text>();
            textNumberT.text = (i+1).ToString();


            //Text_Highscore Score;
            Transform textScore = entryTransform.GetChild(1);
            Text textScoreT = textScore.GetComponent<Text>();
            textScoreT.text = highscoreList[i].score.ToString();
       

           // Text_Highscore Username;
            Transform textUsername = entryTransform.GetChild(2);
            Text textUsernameT = textUsername.GetComponent<Text>();
            textUsernameT.text = highscoreList[i].name.ToString();
      

            entryTransform.gameObject.SetActive(true);
        }

    }

}
