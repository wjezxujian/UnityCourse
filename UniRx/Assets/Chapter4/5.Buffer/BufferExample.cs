using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class BufferExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Observable.Interval(TimeSpan.FromSeconds(1.0f)).Buffer(TimeSpan.FromSeconds(3.0f)).Subscribe(countList => {
        //    Debug.Log(countList);
        //    countList.ToList().ForEach(count => Debug.Log(count));
        //});

        Observable.Interval(TimeSpan.FromSeconds(1.0f)).Buffer(3).Subscribe(countList =>
        {
            Debug.Log(countList);
            countList.ToList().ForEach(count => Debug.Log(count));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
