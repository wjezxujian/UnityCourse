using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
using System;

public class ThreadExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var threadAStream = Observable.Start(() => {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return 10;
        });

        var threadBStream = Observable.Start(() =>
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return 30;
        });

        Observable.WhenAll(threadAStream, threadBStream)
            .ObserveOnMainThread().Subscribe(reuslts =>
            {
                Debug.LogFormat("{0}:{1}", reuslts[0], reuslts[1]);
            });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
