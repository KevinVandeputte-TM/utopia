using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using TMPro;
using UnityEngine.UI;


public class Start_World : MonoBehaviour
{
    API_calls sn;
    public GameObject characterOriginal;
    public GameObject answerButton;
    public SpriteLibraryAsset color1;
    public SpriteLibraryAsset color2;
    public SpriteLibraryAsset color3;
    public SpriteLibraryAsset color4;
    public SpriteLibraryAsset color5;
    public TextMeshProUGUI stationText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI questionText;
    public GameObject UI_question;
    public List<QuestionModel> questionList;
    GameObject UIq;
    private CurrentUser currentUser;
    private int stationID;

    //Start is called before the first frame update
    async void Start()
    {

        UI_question.SetActive(false);

         //get currentUser, stationID, stationText;
        currentUser = CurrentUser.getCurrentUser();
        stationID = CurrentUser.Instance.getCurrentStationID();
        scoreText.text = "Score: ";
        stationText.text = "Station";

        //get API SCRIPT OBJECT
        sn = gameObject.GetComponent<API_calls>();

        //api call to get questions
        questionList = await sn.GetQuestionsByStation(stationID);

        //array of colors for character
        SpriteLibraryAsset[] listOfColors= { color1, color2, color3, color4, color5 };

        int i = 0;

        //parent
        Transform charcContainer = transform.Find("/charcContainer");

        //create charc per question
        foreach (QuestionModel question in questionList)
        {
            var position = new Vector2(UnityEngine.Random.Range(-10.0f, 10.0f), UnityEngine.Random.Range(-10.0f, 10.0f));

            //clone object
            GameObject otherCharcClone = Instantiate(characterOriginal,position,characterOriginal.transform.rotation, charcContainer);
            otherCharcClone.gameObject.name = "OtherCharacter_" + i;

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
        if (currentUser.getCurrentStation() != null && currentUser.getCurrentStationID()>0) {
            stationText.text = currentUser.getCurrentStation().education;
            scoreText.text = "Score: " + currentUser.getUser().score.ToString();
       }
        
    }

    public void showQuestion(Character_base obj)
    {   
        //Open the canvas
        UI_question.SetActive(true); 

        //Set the questions text
        questionText.text = questionList[obj.questionID_list].question;

        //Get list of answers    
        List<string> answers = new List<string>();
        
        answers.Add(questionList[obj.questionID_list].correctanswer);
        //if answer is not empty add to list
        if(questionList[obj.questionID_list].fOne != ""){
            answers.Add(questionList[obj.questionID_list].fOne);
        }

        if(questionList[obj.questionID_list].fTwo != ""){
            answers.Add(questionList[obj.questionID_list].fTwo);
        }

        if(questionList[obj.questionID_list].fThree != ""){
            answers.Add(questionList[obj.questionID_list].fThree);
        }
        
        //shuffle answerslist.
        answers.shuffleList();

        //setting up the snawer buttons
        float templateHeight = 200f;

        int i = 0;
        // loop over answers
        foreach (var answer in answers)
        {
            //parent
            Transform entryContainer = transform.Find("/UI_question/Canvas/Questionbox/Answerbuttons");
            entryContainer.GetComponent<AnswerButtonController>().maxIndex = answers.Count - 1;
            var position = new Vector2(0, 0);

            //duplicate the parent
            GameObject buttonAnswerFilled = Instantiate(answerButton, position, answerButton.transform.rotation, entryContainer);
            buttonAnswerFilled.gameObject.name = "answer" + i.ToString();
            //set anchor position
            RectTransform rectRectTransform = buttonAnswerFilled.GetComponent<RectTransform>();
            rectRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            // fill button text
            buttonAnswerFilled.GetComponentInChildren<TextMeshProUGUI>().text = answer;
            //set index of button
            buttonAnswerFilled.GetComponent<AnswerButton>().thisIndex = i;

            if(answer == questionList[obj.questionID_list].correctanswer){
                buttonAnswerFilled.GetComponent<AnswerButton>().correctanswer = true;
            }

            i++;
        }        
    }

    public void checkAnswer(bool myanswer)
    {
        if(myanswer){
            currentUser.setScore();
        }

        UI_question.SetActive(false);

        //reset player to !isBusy and canMove
        PlayerController player = GameObject.Find("/Astronaut").GetComponent<PlayerController>();
        player.isBusy = false; 
        player.canMove = true;
    }

}

// Helper class for shuffling lists
public static class Helper{
    public static void shuffleList<T>(this List<T> list){
        var rnd = new System.Random();
        int n = list.Count; 
        while (n > 1) {  
            n--;  
            int k = rnd.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }     
    }

}
