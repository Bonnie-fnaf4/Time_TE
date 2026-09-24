using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : MonoBehaviour
{
    [SerializeField] private string _url = "https://yandex.com/time/sync.json";

    void Start()
    {
        // Запускаем корутину для отправки запроса
        StartCoroutine(GetRequest(_url));
    }

    IEnumerator GetRequest(string url)
    {
        // Создаем GET-запрос
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Отправляем запрос и ждем завершения
            yield return webRequest.SendWebRequest();

            // Проверяем на ошибки
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"Ошибка: {webRequest.error}");
                    break;
                case UnityWebRequest.Result.Success:
                    // Получаем текстовый ответ от сервера
                    Debug.Log($"Ответ: {webRequest.downloadHandler.text}");
                    break;
            }
        }
    }
}
