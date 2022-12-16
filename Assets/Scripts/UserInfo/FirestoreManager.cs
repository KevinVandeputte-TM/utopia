using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Linq;


public class FirestoreManager : MonoBehaviour
{
    [SerializeField] Button start;

    FirebaseFirestore db;
    ToggleGroup toggleGroup;

    private string playerName = "";
    private int birthYear = 0;
    private string gender = "";

    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        start.onClick.AddListener(OnHandleClick);
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void OnHandleClick()
    {
/*        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
*/        UserInfo userInfo = new UserInfo
        {
            Playername = playerName,
            UserId = 1,
            Birthyear = birthYear,
/*            Gender = toggle.GetComponentInChildren<Text>().text,
*/            Gender = "test",
            Score = 0
        };
        DocumentReference userRef = db.Collection("users").Document();
        userRef.SetAsync(userInfo).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Updated User");
        });
    }

    public void ReadStringInput(string s)
    {
        playerName = s;
    }

    public void ReadBirthYearInput(int i)
    {
        birthYear = i;
    }

    public void ReadGender(string s)
    {
        gender = s;
    }
}
