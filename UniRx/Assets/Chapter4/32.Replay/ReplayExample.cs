using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ReplayExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var replayObservable = Observable.Interval(TimeSpan.FromSeconds(1.0F))
            .Do(l => Debug.LogFormat("Observable: {0}", l))
            //.Publish()
            .Replay();

        replayObservable.Subscribe(l => Debug.LogFormat("Subscription #1: {0}", l));
        replayObservable.Connect();

        Observable.Timer(TimeSpan.FromSeconds(5.0f))
            .Subscribe(_ =>
            {
                replayObservable.Subscribe(l => Debug.LogFormat("Subscription #2: {0}", l)); 

            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
