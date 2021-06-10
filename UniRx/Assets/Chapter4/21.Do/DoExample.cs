using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//Do理解成为一个Observable
public class DoExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.ReturnUnit()
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => Debug.Log("After 1 seconds"))
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => Debug.Log("After 2 seconds"))
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => Debug.Log("After 3 seconds"), () => Debug.Log("After 5 seconds"))
            .Delay(TimeSpan.FromSeconds(1.0f))
            .Do(_ => Debug.Log("After 4 seconds"))
            
            .Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
