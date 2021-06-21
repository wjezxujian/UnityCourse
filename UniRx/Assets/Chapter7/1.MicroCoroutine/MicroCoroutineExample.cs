using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class MicroCoroutineExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.frameCount);
        Observable.FromMicroCoroutine(_ => DelayFrames(3)).Subscribe();
    }

    IEnumerator DelayFrames(int frameCount)
    {
        for (int i = 0; i < frameCount; ++i)
        {
            yield return null;
        }

        Debug.Log(Time.frameCount);
        
    }
    
}
