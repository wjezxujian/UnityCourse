using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class IgnoreElementsExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        var ignoreElemetsSubject = subject.IgnoreElements();

        subject.Subscribe(i => Debug.LogFormat("Subscribe 1: {0}", i), () => Debug.LogFormat("subject.OnCompleted()"));

        ignoreElemetsSubject.Subscribe(i => Debug.LogFormat("Subscribe 2: {0}", i), () => Debug.LogFormat("ignoreElemetsSubject.OnCompleted()"));

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
