using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LeaveWorld : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;

    // Start is called before the first frame update
    void Start()
    {
        exitPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
	if(Input.GetKeyDown("escape")){
            exitPanel.SetActive(true);
        }
    
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Astronaut")
        {
            exitPanel.SetActive(true);
        }


    }

    public void onUserClickYesNo(int choice)
    {//choice==0 no     choice==1 yes
        if (choice == 1)
        {
            SceneManager.LoadScene("Metronetwork");

        }
        exitPanel.SetActive(false);//else
    }

}
