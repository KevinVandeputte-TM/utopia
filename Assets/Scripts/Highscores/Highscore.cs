using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("entryTemplate");
        float templateHeight = 100f;

        entryTemplate.gameObject.SetActive(false);

        for (int i=0; i < 15; i++)
        {
Transform entryTransform = Instantiate(entryTemplate,entryContainer);
            RectTransform rectRectTransform = entryTransform.GetComponent<RectTransform>();
            rectRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }

    }

}
