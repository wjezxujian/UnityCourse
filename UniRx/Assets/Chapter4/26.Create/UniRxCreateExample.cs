using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxCreateExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Create<int>(observable =>
        {
            observable.OnNext(1);
            observable.OnNext(2);

            Observable.Timer(TimeSpan.FromSeconds(1.0f)).Subscribe(_ => observable.OnCompleted());

            return Disposable.Create(() => Debug.Log("观察者已被销毁"));
        }).Subscribe(number => Debug.LogFormat("number is :{0}", number));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
