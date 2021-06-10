using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxAggregateExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        subject.Aggregate((max, nextValue) => max = max > nextValue ? max : nextValue).Subscribe(result => Debug.Log(result));

        subject.OnNext(1);
        subject.OnNext(3);
        subject.OnNext(100);
        subject.OnNext(50);
        subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
