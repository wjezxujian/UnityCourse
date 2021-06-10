using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TimeoutFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Do(_ => Debug.LogFormat("clicked frame: {0}", Time.frameCount))
            .TimeoutFrame(600)
            .Subscribe(_ => Debug.Log("Clicked"), ex => {
                Debug.LogFormat("exception frame count: {0}", Time.frameCount);
                Debug.LogError(ex);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
