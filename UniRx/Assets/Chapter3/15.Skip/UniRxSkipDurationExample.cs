using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxSkipDurationExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => "Left Mouse Clicked").Skip(TimeSpan.FromSeconds(5f)).Subscribe(value =>
        {
            Debug.Log(value);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
