using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Simple Float", menuName = "SimpleFloat", order = 51)]
public class TimeValue : ScriptableObject
{
    [NonSerialized]
    public float TotalTime;
    public string TotalTimeText
    {
        get
        {
            TimeSpan ts = TimeSpan.FromSeconds(TotalTime);
            return string.Format("{0:D2}h:{1:D2}m:{2:D2}s", ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
