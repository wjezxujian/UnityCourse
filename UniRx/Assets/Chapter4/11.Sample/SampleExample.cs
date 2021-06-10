using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class SampleExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int clickCount = 0;
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => clickCount++).Sample(TimeSpan.FromSeconds(3f)).Subscribe(_ =>
        {
            Debug.LogFormat("��{0}���ε��", clickCount);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
