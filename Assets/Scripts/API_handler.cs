using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.Text;



public class API_handler
{
    public async Task<T> Get<T>(string url)
    {
        using var www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Access-Control-Allow-Origin", "*");
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
          //  Debug.Log($"Success:  {www.downloadHandler.text}");
            return result;
        }
        catch 
        {
          //  Debug.LogError($"{this} Could not parse response {ex.Message}");
            return default;
        }
    }
  
    public async Task Put(string url, UserModel user)
    {
        //user to json
        string json = JsonConvert.SerializeObject(user);

        //putting out request
        using var www = UnityWebRequest.Put(url, json);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        www.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Access-Control-Allow-Origin", "*");

        var operation = www.SendWebRequest();
        //response not right away
        while (!operation.isDone)
            await Task.Yield();


        www.Dispose();
    }

    public async Task<T> Post<T>(string url, UserModel user)
    {
        //user to json
        string json = JsonConvert.SerializeObject(user);

        //putting out request
        using var www = UnityWebRequest.Post(url, json);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        www.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Access-Control-Allow-Origin", "*");

        var operation = www.SendWebRequest();

        //response not right away
        while (!operation.isDone)
            await Task.Yield();

        var jsonResponse = www.downloadHandler.text;
        www.Dispose();
        try {
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);
            //  Debug.Log($"Success:  {www.downloadHandler.text}");
          
            return result;
        }
        catch 
        {
           // Debug.LogError($"{this} Could not parse response {ex.Message}");
            return default;
        }

     
    }

    public async Task PostVisit(string url) {
        // using var request = UnityWebRequest.Post(url);
        using var www = new UnityWebRequest(url, "PUT");

        var operation = www.SendWebRequest();

        //response not right away
        while (!operation.isDone)
            await Task.Yield();

        www.Dispose();
    }
}
