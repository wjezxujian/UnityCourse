using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class TimeoutExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Take(10)
            .Timeout(TimeSpan.FromSeconds(3.0f))
            .Subscribe(times => Debug.Log("Mouse Click: " + times), ex => Debug.LogError(ex.Message));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
