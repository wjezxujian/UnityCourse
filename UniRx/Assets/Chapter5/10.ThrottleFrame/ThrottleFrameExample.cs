using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ThrottleFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var frame = Time.frameCount;

        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Do(_ => {
                Debug.Log("clicked real time");
                frame = Time.frameCount;
             })
            .ThrottleFrame(600)
            .Subscribe(_ => Debug.LogFormat("{0}֡ǰ�����һ�����", Time.frameCount - frame));

    }
}
