using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class AmbExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Amb(
            Observable.Timer(TimeSpan.FromSeconds(3.0f)).Select(_ => "1 sec"),
            Observable.Timer(TimeSpan.FromSeconds(2.0f)).Select(_ => "1 sec"),
            Observable.Timer(TimeSpan.FromSeconds(1.0f)).Select(_ => "1 sec"),
            Observable.Timer(TimeSpan.FromSeconds(5.0f)).Select(_ => "1 sec"),
            Observable.Timer(TimeSpan.FromSeconds(4.0f)).Select(_ => "1 sec"),
            Observable.Timer(TimeSpan.FromSeconds(6.0f)).Select(_ => "1 sec"),
            Observable.Timer(TimeSpan.FromSeconds(8.0f)).Select(_ => "1 sec")
        ).Subscribe(name => Debug.Log(name), () => Debug.Log("On Completed"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
