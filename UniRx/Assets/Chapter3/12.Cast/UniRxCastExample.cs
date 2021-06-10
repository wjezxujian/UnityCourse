using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxCastExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<object>();

        subject.Cast<object, string>().Subscribe(value =>
        {
            Debug.Log(value);
        }, e => {
            Debug.Log("has exception");
            Debug.LogException(e);
        });

        subject.OnNext("123123");
        subject.OnNext("123123");
        subject.OnNext(123);
        subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
