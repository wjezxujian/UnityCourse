using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//判断跟上一次状态是否改变
public class DistinctUntilChangedExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var subject = new Subject<int>();

        //var distinct = subject.DistinctUntilChanged();

        //subject.Subscribe(i => Debug.LogFormat("Subscribe 1：{0}", i), () => Debug.LogFormat("subejct.OnCompleted()"));
        //distinct.Subscribe(i => Debug.LogFormat("distinct.OnNext({0})", i), () => Debug.LogFormat("distinct.OnCompleted()"));

        //subject.OnNext(1);
        //subject.OnNext(2);
        //subject.OnNext(3);

        //subject.OnNext(1);
        //subject.OnNext(1);
        //subject.OnNext(4);
        //subject.OnNext(4);
        //subject.OnNext(3);
        //subject.OnNext(3);
        //subject.OnNext(3);
        //subject.OnCompleted();

        var state = "RunState";

        Observable.EveryUpdate()
            .DistinctUntilChanged(_ => state)
            .Subscribe(stateName => Debug.LogFormat("On state changed: {0}", state));

        Observable.ReturnUnit()
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => state = "JumpState")
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => state = "IdleState")
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => state = "IdleState")
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => state = "IdleState")
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => state = "RunState")
            .Subscribe();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
