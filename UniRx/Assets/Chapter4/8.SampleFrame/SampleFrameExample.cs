using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//隔多少帧进行一次采样
public class SampleFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().SampleFrame(5).Subscribe(frame => Debug.Log("Current Frame:" + frame));



        //Observable.EveryUpdate().SampleFrame(5).Subscribe(frame => GC.Collect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
