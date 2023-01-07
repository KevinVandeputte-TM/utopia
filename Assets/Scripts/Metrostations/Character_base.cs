using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Character_base : MonoBehaviour
{
    //API call 
    public int questionID_list;
   // public int questionID_api;

    GameObject scripts;

    Start_World worldControl;

    private bool isPlayed;

    //public GameObject UI_question;


    // Start is called before the first frame update
    void Start()
    {

       // UI_question = GameObject.Find("UI_question");
        //UI_question.SetActive(false);
        //instantiate the worldControl Object
        scripts = GameObject.Find("Scripts");
        worldControl = scripts.GetComponent<Start_World>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       PlayerController player = collider.gameObject.GetComponent<PlayerController>();
        if (player != null && !isPlayed && !player.isBusy)
        {
            //show question
            worldControl.showQuestion(this);
            //Set charater as played
            isPlayed = true;
            player.isBusy = true;
            player.canMove = false;
        }

    }



}
