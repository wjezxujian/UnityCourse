using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimerExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(5f), TimeSpan.FromSeconds(1f)).Subscribe(_ => Debug.Log("After 5 seconds"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
