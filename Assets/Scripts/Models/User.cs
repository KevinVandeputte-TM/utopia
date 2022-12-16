using System;

namespace Models
{
	[Serializable]
	public class User
	{
		public int userID;


		public string playerName;

		public int score;
	public int birthYear;
		public String intrestArea;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}
