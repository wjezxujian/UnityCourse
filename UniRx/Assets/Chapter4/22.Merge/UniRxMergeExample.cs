using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class UniRxMergeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var aStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => "A");
        var bStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(1)).Select(_ => "B");

        //Observable.Merge(aStream, bStream).Subscribe(name => Debug.Log(name));
        aStream.Merge(bStream).Subscribe(name => Debug.Log(name));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
