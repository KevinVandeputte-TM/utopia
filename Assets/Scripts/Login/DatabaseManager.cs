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
    private string interest = "-";
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
        currentUser = CurrentUser.getCurrentUser();

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
        //set current user properties
        int id = await getUserIDGivenNameAndBirthYear(playerName, int.Parse(birthyear));
        currentUser.setUser(id);
        StationModel startstation = await sn.getStartStation(int.Parse(interest));
        currentUser.setStartStationID(startstation.stationID);

        SceneManager.LoadScene(SceneIndex);
    }

    //get logged in user from list of users
    async Task<int> getUserIDGivenNameAndBirthYear(string name, int birthyear)
    {
        int result = 0;
        List<UserModel> users = await sn.getUsers();
        foreach (UserModel user in users)
        {
            if (result == 0 && user.name.Equals(name) && user.birthyear == birthyear)
            {
                result = user.userID;
            }
        }
        return result;
    }
}