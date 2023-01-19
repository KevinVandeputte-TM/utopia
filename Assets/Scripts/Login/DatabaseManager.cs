using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Networking;
using System.Text;
using System.Threading.Tasks;

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
    CurrentUser currentUser;


    // Start is called before the first frame update
    void Start()
    {
        int menuIndex = dropdownMenu.GetComponent<TMPro.TMP_Dropdown>().value;
        menuOptions = dropdownMenu.GetComponent<TMPro.TMP_Dropdown>().options;

        sn = gameObject.GetComponent<API_calls>();
        currentUser = CurrentUser.GetCurrentUser();

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
        //create user & catch created user
        UserModel user = await sn.addUser(playerName, int.Parse(birthyear), int.Parse(interest));
        
        //set current user properties
        currentUser.SetUser(user.userID);
        StationModel startstation = await sn.getStartStation(int.Parse(interest));
        currentUser.SetStartStationID(startstation.stationID);

        //go to next scene
        SceneManager.LoadScene(SceneIndex);
    }

}