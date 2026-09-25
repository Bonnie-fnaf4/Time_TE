using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataTimeController : MonoBehaviour
{
    [Inject] NetworkController _networkController;
    [SerializeField] private TimeData _timeData = new TimeData();
    private double _currentTimestampMs;

    private void Start()
    {
        _networkController.GetRequest();
    }

    private void Update()
    {
        _currentTimestampMs += Time.unscaledDeltaTime * 1000.0;
    }

    void OnEnable()
    {
        _networkController.GetData += UpdateData;
    }

    void OnDisable()
    {
        _networkController.GetData -= UpdateData;
    }

    private void UpdateData(TimeData.Data data)
    {
        _timeData.currentData = data;
    }

    private DateTimeOffset GetCurrentDateTime()
    {
        var date = DateTimeOffset.FromUnixTimeMilliseconds(_timeData.currentData.time + (long)_currentTimestampMs);
        return date.LocalDateTime;
    }

    public string GetSeconds()
    {
        return GetCurrentDateTime().ToString("ss");
    }
    
    public string GetMinutes()
    {
        return GetCurrentDateTime().ToString("mm");
    }

    public string GetHours()
    {
        return GetCurrentDateTime().ToString("HH");
    }

    public string GetDays()
    {
        return GetCurrentDateTime().ToString("dd");
    }

    public string GetMonths()
    {
        return GetCurrentDateTime().ToString("MM");
    }

    public string GetYears()
    {
        return GetCurrentDateTime().ToString("yyyy");
    }
}
