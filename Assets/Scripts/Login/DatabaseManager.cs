using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Networking;
using System.Text;
[RequireComponent(typeof(API_calls))]


public class DatabaseManager : MonoBehaviour
{
    private string playerName = "";
    private string birthyear = "";
    private string interest = "1";
    public Transform dropdownMenu;
    List<TMPro.TMP_Dropdown.OptionData> menuOptions;

    ToggleGroup toggleGroupInstance;

    API_calls sn;

    // Start is called before the first frame update
    void Start()
    {
        int menuIndex = dropdownMenu.GetComponent<TMPro.TMP_Dropdown>().value;
        menuOptions = dropdownMenu.GetComponent<TMPro.TMP_Dropdown>().options;

        sn = gameObject.GetComponent<API_calls>();
    }

    public void ReadStringInput(string s)
    {
        playerName = s;
    }

    public void ReadBirthYearInput(int i)
    {
        birthyear = menuOptions[i].text;
    }

    public void ReadInterest(Toggle sender){
    // only take notice from Toggle just swtiched to On
        if(sender.isOn){
            interest = sender.tag;
        }
    }

    public async void CreateUser(int SceneIndex) {
        await sn.addUser(playerName, int.Parse(birthyear), int.Parse(interest));

        SceneManager.LoadScene(SceneIndex);
    }
}