using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class API_handler 
{
    //generic type
    public async Task<T> Get<T>(string url)
    {
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
            //async task
            await Task.Yield();

        //deserialize json to object
        var jsonResponse = www.downloadHandler.text;

        try
        {
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);
            Debug.Log($"Success:  {www.downloadHandler.text}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{this} Could not parse response {jsonResponse}: {ex.Message}");
            return default;
        }
    }
}
