using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class DelayFrameSubscriptionExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.frameCount);
        Observable.ReturnUnit()
            .DelayFrame(10)
            .Subscribe(_ => Debug.Log(Time.frameCount)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
