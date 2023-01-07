using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LeaveWorld : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;
    public int exitSceneIndex;
    private Transition transition;
    

    // Start is called before the first frame update
    void Start()
    {
        exitPanel = GameObject.Find("exitPanel");
        exitPanel.SetActive(false);
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
                Time.timeScale = 0;
            }
        }    
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Entrance")
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0;
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
        Time.timeScale = 1;
    }


}
