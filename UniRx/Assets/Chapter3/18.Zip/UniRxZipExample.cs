using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxZipExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var leftStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        var rightStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));

        leftStream.Zip(rightStream, (left, right) => Unit.Default)
            .Subscribe(_ => Debug.Log("Click OK"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
