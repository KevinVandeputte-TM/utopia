using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class API_handler 
{
    public async Task <T> Get<T>(string url)
    {

        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();
        //response not right away
        while (!operation.isDone)

            // // Request and wait for the desired page.
          await Task.Yield(); 
           // yield return www.Send();

        //deserialize json to object
        var jsonResponse = www.downloadHandler.text;
        try
        {
            //  var result = JsonConvert.DeserializeObject<UserModel>(jsonResponse);
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);
            Debug.Log($"Success:  {www.downloadHandler.text}");
           return result;
        }
        catch (Exception ex)
        {
       Debug.LogError($"{this} Could not parse response {ex.Message}");
           return default;
        }
    }
}
