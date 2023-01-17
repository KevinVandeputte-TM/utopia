using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private CurrentUser currentUser;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
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
