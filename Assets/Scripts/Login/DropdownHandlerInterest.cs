using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandlerInterest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<TMPro.TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("-");
        items.Add("Business & Tourism");
        items.Add("Design & Build");
        items.Add("Education");
        items.Add("Life Sciences & Chemistry");
        items.Add("Media & Communication");
        items.Add("People & Health");
        items.Add("Sport");
        items.Add("Tech & IT");

        foreach(var item in items)
        {
            dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData() { text = item });
        }

    }
}
