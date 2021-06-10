using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class DelayExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Delay(TimeSpan.FromSeconds(1f))
        //    .Subscribe(_ => Debug.Log("延时1s输出点击事件。"));

        Observable.Timer(TimeSpan.FromSeconds(1.0f))
            .Select(_ =>
            {
                Debug.Log("1 seconds");
                return _;
            }).Delay(TimeSpan.FromSeconds(1.0f)).Select(_ =>
            {
                Debug.Log("2 seconds");
                return _;
            }).Delay(TimeSpan.FromSeconds(1.0f)).Repeat().Subscribe(_ => Debug.Log("3 seconds"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
