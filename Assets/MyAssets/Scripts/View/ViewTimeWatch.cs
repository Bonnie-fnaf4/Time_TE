using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ViewTimeWatchCircle : MonoBehaviour
{
    [Inject] private DataTimeController _data;
    [SerializeField] private GameObject _hours, _minutes, _seconds;
    [SerializeField] private bool isSlow;

    private void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        
        transform.DOScale(new Vector3(1f, 1f, 1f), Random.Range(0.5f, 1.5f));
    }


    private void Update()
    {
        UpdateClockRotation(_data.GetHoursFloat(), _data.GetMinutesFloat(), _data.GetSecondsFloat(), _data.GetMiliSecondsFloat());
    }

    private void UpdateClockRotation(float hours, float minutes, float seconds, float milliseconds)
    {
        float secondsAngle;
        
        if(isSlow) secondsAngle = (seconds * 6f) + (milliseconds * 0.006f);
        else secondsAngle = seconds * 6f;
        
        float minutesAngle = minutes * 6f;
        
        float hoursAngle = (hours % 12f) * 30f;
        
        _seconds.transform.localRotation = Quaternion.Euler(0f, 0f, -secondsAngle);
        _minutes.transform.localRotation = Quaternion.Euler(0f, 0f, -minutesAngle);
        _hours.transform.localRotation = Quaternion.Euler(0f, 0f, -hoursAngle);
    }
}
