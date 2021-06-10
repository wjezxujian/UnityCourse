using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FrameIntervalExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Timestamp()
            .TimeInterval()
            .FrameInterval()
            .Subscribe(result => Debug.LogFormat("�����ϴε����֡����{0}, ʱ����: {1}", result.Interval, result.Value.Interval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
