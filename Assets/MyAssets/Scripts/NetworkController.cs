using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : MonoBehaviour
{
    public Action<TimeData.Data> GetData;
    
    [SerializeField] private string _url = "https://yandex.com/time/sync.json";
    
    // void Start()
    // {
    //     GetRequest();
    // }

    public void GetRequest()
    {
        StartCoroutine(GetRequestCoroutine(_url));
    }

    IEnumerator GetRequestCoroutine(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError($"Ошибка: Подключения");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"Ошибка: Ошибка получения данных");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"Ошибка: {webRequest.error}");
                    break;
                case UnityWebRequest.Result.Success:
                    
                    var data = JsonUtility.FromJson<TimeData.Data>(webRequest.downloadHandler.text);
                    GetData?.Invoke(data);
                    
                    Debug.Log(data.time);
                    
                    Debug.Log($"Ответ: {webRequest.downloadHandler.text}");
                    
                    break;
            }
        }
    }
}
