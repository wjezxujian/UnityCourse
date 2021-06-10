using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScanExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Observable.Range(0, 8).Scan(0, (acc, currentValue) => acc + currentValue).Subscribe(number => Debug.Log(number));

        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Scan(0, (times, nextValue) => ++times)
            .Subscribe(times => Debug.LogFormat("clicked {0} times", times));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
