using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CatchExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Throw<string>(new Exception("error")).Catch<string, Exception>(ex =>
        {
            Debug.LogFormat("Catch exception: {0}", ex.Message);

            return Observable.Timer(TimeSpan.FromSeconds(1f)).Select(_ => "timer called");
        }).Subscribe(result => Debug.Log(result));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
