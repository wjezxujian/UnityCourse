using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class DelaySubscription : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.time);

        Observable.ReturnUnit().DelaySubscription(TimeSpan.FromSeconds(1)).Subscribe(_ => Debug.Log(Time.time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
