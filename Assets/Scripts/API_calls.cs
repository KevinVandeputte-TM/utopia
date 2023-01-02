using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

using Newtonsoft.Json;
using UnityEditor.Networking;
using UnityEngine.Networking;
using TMPro;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.ComponentModel;
using Unity.VisualScripting;

public class API_calls :MonoBehaviour
{
    //highscores

    public async IAsyncEnumerator<List<UserModel>> GetHighscores()
    {
        var apiHandler = new API_handler();
        var url = "https://edge-service-utopia-kevinvandeputte-tm.cloud.okteto.net/highscores/";
       var result = apiHandler.Get<List<UserModel>>(url).Result;

        yield return result;
          
    }

    //if (www.result != UnityWebRequest.Result.Success)
    //{
    //    Debug.Log(www.error);
    //}
    //else
    //{
    //    // Show results as text
    //    Debug.Log(www.downloadHandler.text);

    //    // Or retrieve results as binary data


    //    var jsonResponse = www.downloadHandler.text;
    //    try
    //    {
    //        //  var result = JsonConvert.DeserializeObject<UserModel>(jsonResponse);
    //        var result = JsonConvert.DeserializeObject<List<UserModel>>(jsonResponse);
    //        Debug.Log($"Success:  {www.downloadHandler.text}");
    //        //  return result;
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.LogError($"{this} Could not parse response {ex.Message}");
    //        //    return default;
    //    }





}





       

    




