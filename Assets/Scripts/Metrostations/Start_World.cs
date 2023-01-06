using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using TMPro;
using UnityEngine.UI;


public class Start_World : MonoBehaviour
{


    API_calls sn;
    public GameObject characterOriginal;
    public SpriteLibraryAsset color1;
    public SpriteLibraryAsset color2;
    public SpriteLibraryAsset color3;
    public SpriteLibraryAsset color4;
    public SpriteLibraryAsset color5;
    public TextMeshProUGUI stationText;
    public TextMeshProUGUI questionText;
    public GameObject UI_question;
    public List<QuestionModel> questionList;
    GameObject UIq;
    //Start is called before the first frame update
    async void Start()
    {

        UI_question.SetActive(false);
        //get API SCRIPT OBJECT
        sn = gameObject.GetComponent<API_calls>();

        //api call to get questions
        questionList = await sn.GetQuestionsByStation(9);
        Debug.Log(questionList);

        //array of colors for character
        SpriteLibraryAsset[] listOfColors= { color1, color2, color3, color4, color5 };

        int i = 0;
     

        foreach (QuestionModel question in questionList)
        {
            var position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));

            //clone object
            GameObject otherCharcClone = Instantiate(characterOriginal,position,characterOriginal.transform.rotation);

            //set colorscheme character
            otherCharcClone.gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = listOfColors[i];

            //set variables for questions
            otherCharcClone.gameObject.GetComponent<Character_base>().questionID_list= i;
            //otherCharcClone.gameObject.GetComponent<Character_base>().questionID_api = question.questionID;
               
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        stationText.text = CurrentUser.Instance.currentStation.education + "   (score: " + CurrentUser.Instance.user.score + ")";
    }

    public void showQuestion(Character_base obj)
    {
        questionText.text = questionList[obj.questionID_list].question;
        UI_question.SetActive(true);

    }
}
