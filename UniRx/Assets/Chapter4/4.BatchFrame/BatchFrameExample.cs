using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BatchFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .BatchFrame(1000, FrameCountType.EndOfFrame)
            .Subscribe(clicks => Debug.Log(clicks.Count));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
