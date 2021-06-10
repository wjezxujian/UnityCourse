using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class RefCountExample : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        var refCountObservable = Observable.Interval(TimeSpan.FromSeconds(1.0f))
            .Do(l => Debug.LogFormat("Publishing {0}", l))
            .Publish()
            .RefCount();

        var subscription1 = refCountObservable.Subscribe(l => Debug.LogFormat("Subscribe #1: {0}", l));

        yield return new WaitForSeconds(5.0f);

        var subscription2 = refCountObservable.Subscribe(l => Debug.LogFormat("Subscribe #2: {0}", l));

        yield return new WaitForSeconds(5.0f);

        subscription1.Dispose();

        yield return new WaitForSeconds(5.0f);

        subscription2.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
