using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimestampExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Observable.Interval(TimeSpan.FromSeconds(1f)).Timestamp().Subscribe(timestamp => Debug.LogFormat("{0}", timestamp.Timestamp));

        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Timestamp().Subscribe(timestamp => Debug.LogFormat("timestamp: {0}", timestamp.Timestamp.LocalDateTime));;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
