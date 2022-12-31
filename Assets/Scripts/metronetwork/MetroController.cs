using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sci Fi Train by FiveBrosStopMosYT licensed under CC-BY 4.0.

public class MetroController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PositionFromInterestId();
 
        
    }

    // Update is called once per frame
 void Update()
   {
      /* float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");


      Vector2 position = transform.position;
      position.x = position.x + 15f * horizontal * Time.deltaTime;
      position.y = position.y + 15f * vertical * Time.deltaTime;

      transform.position = position;
*/
   }

 void PositionFromInterestId() {
        //get metroId
        int metrofrominterestId = 1;
        // get position from metroId
        Vector2 position = transform.position;
        string name = "StationID"+metrofrominterestId.ToString();
        Vector2 newPosition = GameObject.Find(name).transform.position; 

      

        transform.position = newPosition;
    }


 void PositionFromWorld() { }


}
