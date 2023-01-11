using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class LeaveWorld : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;
    private Transition transition;
    PlayerController player;
    MetroController metro;
    public bool isMetroStation;



    // Start is called before the first frame update
    void Start()
    {
        exitPanel = GameObject.Find("exitPanel");
        exitPanel.SetActive(false);
        if (isMetroStation) {
            player = gameObject.GetComponent<PlayerController>();

        }
        else
        {
            metro = GameObject.Find("Metro").GetComponent<MetroController>();


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            //if in exitPanel: return to game
            if (exitPanel.activeSelf) {
                exitPanel.SetActive(false);
                if(metro != null) {
                    // set metro can move
                    metro.canMove = true;
                }

                if (player != null && !player.isBusy)
                {
                    //Set player busy 
                    player.isBusy = false;
                    player.canMove = true;

                }

            }
            //else activate exitPanel
            else { 
                exitPanel.SetActive(true);
                if (metro != null)
                {
                   //lock metro
                   metro.canMove = false;
                }

                if (player != null && !player.isBusy)
                {
                    //show exitpanel
                    exitPanel.SetActive(true);
                    //Set player busy 
                    player.isBusy = true;
                    player.canMove = false;

                }

            }
        }    
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Entrance")
        {
            
            if (player != null && !player.isBusy)
            {
                //show exitpanel
                exitPanel.SetActive(true);
                //Set player busy 
                player.isBusy = true;
                player.canMove = false;
               
            }

        }
    }

    public void onUserClickYesNo(int choice, int indexToNavigateTo)
    {
        //choice==0 no     choice==1 yes
        // leave metrostation
        if (choice == 1)
        {
           CurrentUser.Instance.setCurrentStation(0);
           transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
           transition.LoadLevel(indexToNavigateTo);

        }
        // return to game
        exitPanel.SetActive(false);
        if(player != null)
        {
            player.isBusy = false;
            player.canMove = true;

        }
        if (metro != null)
        {
            // set metro can move
            metro.canMove = true;

        }

    }


}
