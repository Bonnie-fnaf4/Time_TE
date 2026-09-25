using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    [SerializeField] private TMP_Text _loadingText;
    
    private Coroutine _loadingCoroutine;
    void Start()
    {
        _loadingCoroutine = StartCoroutine(Loading());
    }

    private void OnDisable()
    {
        StopCoroutine(_loadingCoroutine);
    }

    IEnumerator Loading()
    {
        int counter = 0;
        while (true)
        {
            counter++;

            switch (counter)
            {
                case 0: _loadingText.text = "Loading"; break;
                case 1: _loadingText.text = "Loading."; break;
                case 2: _loadingText.text = "Loading.."; break;
                case 3:
                {
                    _loadingText.text = "Loading...";
                    counter = -1;
                    break;
                }
            }

            yield return new WaitForSeconds(1);
        }
    }
}
