using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(API_calls))]
public class Highscore : MonoBehaviour
{


    private Transform entryContainer;
    private Transform entryTemplate;
    API_calls sn= new API_calls();
       


    void Start()
    {
        sn = gameObject.GetComponent<API_calls>();
      var result=  sn.GetHighscores();

Debug.Log(result);


     


        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("entryTemplate");
        float templateHeight = 100f;

        entryTemplate.gameObject.SetActive(false);

        //api call

        //    var result = sn.GetHighscores().Result;
    

        for (int i=0; i < 15; i++)
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
            //   Debug.Log(textNumber);

            //Text_Highscore Score;
            Transform textScore = entryTransform.GetChild(1);
            Text textScoreT = textScore.GetComponent<Text>();
            textScoreT.text = "SCORE" + i;
            Debug.Log(textScore);

           // Text_Highscore Username;
            Transform textUsername = entryTransform.GetChild(2);
            Text textUsernameT = textUsername.GetComponent<Text>();
            textUsernameT.text = "USERNAME" + i;
            Debug.Log(textUsernameT);

            entryTransform.gameObject.SetActive(true);
        }

    }

}
