using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxConcatExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var leftMouseClickStrem = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Take(5).Select(_ => "A");
        var rightMouseClickStrem = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Take(2).Select(_ => "B");

        leftMouseClickStrem.Concat(rightMouseClickStrem).Subscribe(clickEvent =>
        {
            Debug.Log(clickEvent);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
