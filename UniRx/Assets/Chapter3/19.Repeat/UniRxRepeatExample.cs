using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxRepeatExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(1.0f)).Delay(TimeSpan.FromSeconds(1.0f)).Repeat().Subscribe(_ => Debug.Log("after 1 seconds"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
