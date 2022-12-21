using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using Firebase.Firestore;
// using Firebase.Extensions;
using System.Linq;
using UnityEngine.Networking;
using System.Text;


public class DatabaseManager : MonoBehaviour
{
    private string playerName = "";
    private string birthyear = "";
    private string interest = "-";
    public Transform dropdownMenu;
    List<TMPro.TMP_Dropdown.OptionData> menuOptions;

    ToggleGroup toggleGroupInstance;


    // Start is called before the first frame update
    void Start()
    {
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

    public void ReadInterest(Toggle sender){
    // only take notice from Toggle just swtiched to On
        if(sender.isOn){
            interest = sender.tag;
            print ("option changed to = " + interest);
        }
    }

    public void CreateUser(int SceneIndex) {
        Debug.Log(playerName);
        Debug.Log(birthyear);
        Debug.Log(interest);

        StartCoroutine(SendData());

        SceneManager.LoadScene(SceneIndex);
    }

 

    IEnumerator SendData() {
        UserCreate user = new UserCreate();
        user.birthYear = int.Parse(birthyear);
        user.name = playerName;
        user.interest = interest;
        string json = JsonUtility.ToJson(user, true);

        string uri = "http://localhost:8080/users/save";

        var request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
        request.Dispose();
    }
}



   // public void SaveToJson() {
    //     User user = new User();
    //     user.birthYear = birthyear;
    //     user.name = name;
    //     user.gender = gender;

    //     string json = JsonUtility.toJson(user, true);
    //     File.WriteAllText(Application.dataPath + "/UserDataFile.json", json);
    // }

    // public void LoadFromJson() {
    //     string json = File.ReadAllText(Application.dataPath + "/UserDataFile.json");
    //     User user = JsonUtility.FromJson<User>(json);
    // }