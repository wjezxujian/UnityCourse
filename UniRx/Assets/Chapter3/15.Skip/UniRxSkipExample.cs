using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSkipExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => "Left Mouse Clicked").Skip(3).Subscribe(value =>
        {
            Debug.Log(value);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
