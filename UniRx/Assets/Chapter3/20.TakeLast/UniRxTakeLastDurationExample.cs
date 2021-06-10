using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxTakeLastDurationExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<float>();

        subject.TakeLast(TimeSpan.FromSeconds(2f)).Subscribe(clickTime => Debug.Log(clickTime));

        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => subject.OnNext(Time.time));

        Observable.Timer(TimeSpan.FromSeconds(5f)).Subscribe(_ => subject.OnCompleted());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
