using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    public TextMeshProUGUI notTitle;
    public TextMeshProUGUI notSubtitle;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    public void Notify(string title, string subtitle){
        notTitle.text = title;
        notSubtitle.text = subtitle;
        animator.SetBool("show", false);
        animator.SetBool("show", true);
    }
}
