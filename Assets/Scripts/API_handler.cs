using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class API_handler
{
    public async Task<T> Get<T>(string url)
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
            //  JSON to .net object
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



    public async Task Put<T>(string url, UserModel user)
    {
        //user to json
        string json = JsonConvert.SerializeObject(user);
        //putting out request
        using var www = UnityWebRequest.Put(url, json);
        www.SetRequestHeader("Content-Type", "application/json");


        var operation = www.SendWebRequest();
        //response not right away
        while (!operation.isDone)
            await Task.Yield();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }

    }
}
