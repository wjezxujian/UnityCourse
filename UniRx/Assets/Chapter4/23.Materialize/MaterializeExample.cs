using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MaterializeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        var onlyExceptions = subject.Materialize().Where(notification => notification.Exception != null).Dematerialize();

        subject.Subscribe(i => Debug.LogFormat("Subscriber 1: {0}", i), ex => Debug.LogFormat("Subscriber 1 exception: {0}", ex.Message));

        onlyExceptions.Subscribe(i => Debug.LogFormat("Subscribe 2: {0}", i), ex => Debug.LogFormat("Subscriber 2 exception: {0}", ex.Message));

        subject.OnNext(123);
        subject.OnError(new System.Exception("Test Exception"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
