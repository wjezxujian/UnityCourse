using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;


//connect 数据在connect时才并行发射
public class PublishExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var unshared = Observable.Range(0, 4);

        unshared.Subscribe(number => Debug.LogFormat("unShared Observable #1: {0}", number));
        unshared.Subscribe(number => Debug.LogFormat("unShared Observable #2: {0}", number));

        var shared = unshared.Publish();

        shared.Subscribe(number => Debug.LogFormat("shared Observable #1: {0}", number));
        shared.Subscribe(number => Debug.LogFormat("shared Observable #2: {0}", number));

        Observable.Timer(TimeSpan.FromSeconds(1.0f)).Subscribe(_ => shared.Connect());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
