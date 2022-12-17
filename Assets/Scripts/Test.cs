using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Test : MonoBehaviour
{

   public Text text;

    [ DllImport("__Internal")]
        public static extern void GetJSON(string path, string objectName, string callback, string fallback);


    private void Start()
    {
        GetJSON("example", gameObject.name, "onRequestSuccess", "onRequestFailed");

    }


    private void OnRequestSuccess(string data)
    {
       text.text = data;
    }
    private void onRequestFailed(string error)
    {
      text.text = error;
    }
}
