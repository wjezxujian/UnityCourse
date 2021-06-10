using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class IntervalExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //Observable.Timer(TimeSpan.FromSeconds(0.05)).Repeat().Subscribe(times => Debug.Log(times));
        Observable.Interval(TimeSpan.FromSeconds(0.5f)).Subscribe(times => Debug.Log(times));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
