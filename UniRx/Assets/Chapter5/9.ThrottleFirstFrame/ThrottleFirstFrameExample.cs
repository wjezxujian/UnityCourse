using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ThrottleFirstFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .ThrottleFirstFrame(500)
            .Subscribe(_ => Debug.Log("Mouse clicked"));

        Observable.EveryUpdate().SampleFrame(500).Subscribe(_ => Debug.Log("Frame clean."));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
