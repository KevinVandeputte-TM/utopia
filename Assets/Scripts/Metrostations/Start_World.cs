using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

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
    public TextMeshProUGUI nrQText;
    public GameObject UI_question;
    public List<QuestionModel> questionList;
    GameObject UIq;
    private CurrentUser currentUser;
    private int stationID;
    private int nrQ;
    Notification notification;



    //Start is called before the first frame update
    async void Start()
    {

        //hide UI questions canvas when starting => only appears when collide player
        UI_question.SetActive(false);

        //loading canvas - show at startup
        Transform loadingcanvas = transform.Find("/Loading");
        loadingcanvas.gameObject.SetActive(true);


        //information UI -with scores
       // Transform informationObject = transform.Find("/UI_Information");
      //  informationObject.gameObject.SetActive(false);




        //get currentUser, stationID, stationText;
        currentUser = CurrentUser.GetCurrentUser();
        //stationID = 1000;
        stationID = CurrentUser.Instance.GetCurrentStationID();
        //scoreText.text = "Score: ";
        stationText.text = "Station";

        //get API SCRIPT OBJECT
        sn = gameObject.GetComponent<API_calls>();

        //api call to get questions
        questionList = await sn.GetQuestionsByStation(stationID);

        //if questions are fetch = stop loading anime
        if (questionList.Count > 0)
        {
           // informationObject.gameObject.SetActive(true);
            //show loading when questionlist is empty
            // loadingcanvas.gameObject.SetActive(true);
        }





        //array of colors for character
        SpriteLibraryAsset[] listOfColors= { color1, color2, color3, color4, color5 };

        int i = 0;

        //parent, where the clone characters will be placed under
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

        //Setting up the number of questions
        nrQ = questionList.Count;
        nrQText.text = nrQ.ToString();

        //selecting the notification
        notification = GameObject.Find("/UI_Information/Notification").GetComponent<Notification>();

    }

    // Update is called once per frame
    void Update()
    {
        //set score and name station
        if (currentUser.GetCurrentStation() != null && currentUser.GetCurrentStationID()>0) {
            stationText.text = currentUser.GetCurrentStation().education;
            scoreText.text = currentUser.GetUser().score.ToString();
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

    /* CHECKING QUESTION RESPONSES */
    public void checkAnswer(bool myanswer)
    {

        //Keeping the UI Question open/active a little longer so button colors can appear
        int i = 300;
        do { 
            i--;
            UI_question.SetActive(true);
        } while( i > 0);

        /* Delete the generated answerbuttons */
        //Select the parent GameObject
        GameObject buttons = GameObject.Find("/UI_question/Canvas/Questionbox/Answerbuttons");
        //Delete the children
        for (int j = 0; j < buttons.transform.childCount; j++){
            Destroy(buttons.transform.GetChild(j).gameObject);
        }

        //Hide the UI Question Canvas
        UI_question.SetActive(false);

        // Select the Player and the PlayerController component which holds the script
        PlayerController player = GameObject.Find("/Astronaut").GetComponent<PlayerController>();

        /* answer logic */
        //if answer is correct    
        if(myanswer){
            currentUser.SetScore();
            player.Celebrate();
            // if wrong answer
        } else {
            player.Wrong();
        }

        //Lower to nr of questions left
        if(nrQ > 0){
            nrQ -= 1;
            nrQText.text = nrQ.ToString();
        }

        //Show notification when level completed
        if(nrQ == 0){
            notification.Notify("Level voltooid!", "KEER TERUG NAAR DE METRO");
            player.canLeave = true;
        }
        
        //reset player to !isBusy and canMove so he can move around and accept questions.
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
