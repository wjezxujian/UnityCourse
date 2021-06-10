using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class DelayFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.frameCount);

        Observable.ReturnUnit()
            .Do(_ => Debug.Log(Time.frameCount))
            .DelayFrame(10)
            .Do(_ => Debug.Log(Time.frameCount))
            .Subscribe(_ => Debug.Log(Time.frameCount));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
