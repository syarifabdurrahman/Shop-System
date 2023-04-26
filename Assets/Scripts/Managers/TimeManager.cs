using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private void Update()
    {
        GetTime();
    }

    private void GetTime()
    {
        // Get the current date and time
        DateTime currentDateTime = DateTime.Now;

        DayOfWeek day = currentDateTime.DayOfWeek;
        string hour = currentDateTime.Hour < 10 ? "0" + currentDateTime.Hour.ToString() : currentDateTime.Hour.ToString();
        string minute = currentDateTime.Minute.ToString();
        string second = currentDateTime.Second.ToString();

        UIManager.Instance.UpdateTime(day, hour, minute);
    }
}
