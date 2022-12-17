using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<TMPro.TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("-");
        items.Add("2001");
        items.Add("2002");
        items.Add("2003");
        items.Add("2004");
        items.Add("2005");
        items.Add("2006");
        items.Add("2007");

        foreach(var item in items)
        {
            dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData() { text = item });
        }

        // DropdownItemSelected(dropdown);

        // dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    // void DropdownItemSelected(TMPro.TMP_Dropdown dropdown)
    // {
    //     int index = dropdown.value;

    //     TextBox.text = dropdown.options[index].text;
    // }
}
