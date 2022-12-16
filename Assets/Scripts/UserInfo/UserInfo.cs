using Firebase.Firestore;

[FirestoreData]
public struct UserInfo
{
    [FirestoreProperty]
    public int UserId { get; set; }
    [FirestoreProperty]
    public int Birthyear { get; set; }
    [FirestoreProperty]
    public string Playername { get; set; }
    [FirestoreProperty]
    public int Score { get; set; }
    [FirestoreProperty]
    public string Gender { get; set; }

}
