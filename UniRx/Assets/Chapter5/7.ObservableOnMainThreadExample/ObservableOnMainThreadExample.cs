using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
using System;

public class ObservableOnMainThreadExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.time);

        Observable.Start(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1f));
                return 1;
            })
            .ObserveOnMainThread()
            .Subscribe(result =>
            {
                Debug.LogFormat("{0}, {1}", result, Time.time);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
