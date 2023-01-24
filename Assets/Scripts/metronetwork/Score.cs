using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private CurrentUser currentUser;
    public TextMeshProUGUI scoreText;
    
    void Start()
    {
        //get current user
        currentUser = CurrentUser.GetCurrentUser();
    }

    void Update()
    {
        if (currentUser.GetUser() != null)
        {
            scoreText.text = currentUser.GetUser().score.ToString();
        }
    }
}
