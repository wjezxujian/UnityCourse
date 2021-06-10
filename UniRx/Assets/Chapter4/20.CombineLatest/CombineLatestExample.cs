using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class CombineLatestExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = 0, i = 0;

        var leftStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => ++a);
        var rightStream = this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(1)).Select(_ => ++i);

        //Observable.CombineLatest(leftStream, rightStream).Subscribe(names => Debug.LogFormat("a:{0}, i:{1}", names[0], names[1]));
        leftStream.CombineLatest(rightStream, (left, right) => "a:" + left + ", i:" + right).Subscribe(name => Debug.Log(name));



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
