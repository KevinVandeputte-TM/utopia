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



    // Start is called before the first frame update
    void Start()
    {
        exitPanel = GameObject.Find("exitPanel");
        exitPanel.SetActive(false);
        player = gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            //if in exitPanel: return to game
            if (exitPanel.activeSelf) {
                exitPanel.SetActive(false);
                Time.timeScale = 1;
            }
            //else activate exitPanel
            else { 
                exitPanel.SetActive(true);
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

    public void onUserClickYesNo(int choice)
    {
        //choice==0 no     choice==1 yes
        // leave metrostation
        if (choice == 1)
        {
           CurrentUser.Instance.setCurrentStation(0);
           transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
           transition.LoadLevel(4);

        }
        // return to game
        exitPanel.SetActive(false);
        player.isBusy = false;
        player.canMove = true;
    }


}
