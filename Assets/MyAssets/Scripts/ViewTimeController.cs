using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ViewTimeController : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _dayAndMounth;
    [SerializeField] private TMP_Text _years;
    [Inject] private DataTimeController _data;

    // Update is called once per frame
    void Update()
    {
        _time.text = _data.GetHours() + ":" + _data.GetMinutes() + ":" + _data.GetSeconds();
        _dayAndMounth.text = _data.GetMonths() + "/" + _data.GetDays();
        _years.text = _data.GetYears();
    }
}
