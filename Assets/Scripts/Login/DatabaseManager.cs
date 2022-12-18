using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using Firebase.Firestore;
// using Firebase.Extensions;
using System.Linq;


public class DatabaseManager : MonoBehaviour
{
    // FirebaseFirestore db;

    private string playerName = "";
    private string birthyear = "";
    private string gender = "M";
    public Transform dropdownMenu;
    List<TMPro.TMP_Dropdown.OptionData> menuOptions;

    ToggleGroup toggleGroupInstance;


    // Start is called before the first frame update
    void Start()
    {
        // db = FirebaseFirestore.DefaultInstance;
        int menuIndex = dropdownMenu.GetComponent<TMPro.TMP_Dropdown>().value;
        menuOptions = dropdownMenu.GetComponent<TMPro.TMP_Dropdown>().options;


    }

    public void ReadStringInput(string s)
    {
        playerName = s;
        Debug.Log(s);
    }

    public void ReadBirthYearInput(int i)
    {

        birthyear = menuOptions[i].text;
        Debug.Log(birthyear);
    }

    public void ReadGender(Toggle sender){
    // only take notice from Toggle just swtiched to On
        if(sender.isOn){
            gender = sender.tag;
            print ("option changed to = " + gender);
        }
    }

    public void CreateUser(int SceneIndex) {
        Debug.Log(playerName);
        Debug.Log(birthyear);
        Debug.Log(gender);

        SceneManager.LoadScene(SceneIndex);
    }
    

    // public void SendUserInfo()
    // {
    //     User user = new User
    //     {
    //         Playername = playerName,
    //         UserId = 1,
    //         Birthyear =  int.Parse(birthyear),
    //         Gender = "Test",
    //         Score = 0
    //     };
    //     DocumentReference userRef = db.Collection("users").Document();
    //     userRef.SetAsync(user).ContinueWithOnMainThread(task =>
    //     {
    //         Debug.Log("Updated User");

    //     });
    // }
}
