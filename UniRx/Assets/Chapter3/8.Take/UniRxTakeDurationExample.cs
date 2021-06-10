using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRxTakeDurationExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Take(TimeSpan.FromSeconds(5f))
                  .Subscribe(_ =>
                  {
                      Debug.Log("LeftMouseButton CLicked");
                  });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
