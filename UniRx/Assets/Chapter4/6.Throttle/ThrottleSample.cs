using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//事件发生多长时间后再次处理
public class ThrottleSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0)).
            Throttle(TimeSpan.FromSeconds(5f))
            .Subscribe(_ => Debug.Log("鼠标点击延时5秒之后输出"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
