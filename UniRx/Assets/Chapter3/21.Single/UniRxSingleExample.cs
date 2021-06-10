using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSingleExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        subject.Where(number => number % 2 == 0).Single().Subscribe(number => Debug.Log(number), e =>{
            Debug.LogError(e);
        });

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);
        subject.OnCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
