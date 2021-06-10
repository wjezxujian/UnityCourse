using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FrameTimeIntervalExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .FrameTimeInterval()
            .Subscribe(timeIntervale => Debug.Log(timeIntervale.Interval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
