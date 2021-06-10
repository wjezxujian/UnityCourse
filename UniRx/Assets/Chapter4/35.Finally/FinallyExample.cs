using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FinallyExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        var result = subject.Finally(() => Debug.Log("Finally action run.")).Subscribe(number => Debug.Log("OnNext: " + number), ex => Debug.LogError(ex), () => Debug.Log("On Completed."));

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnError(new System.Exception("error"));
        //subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
