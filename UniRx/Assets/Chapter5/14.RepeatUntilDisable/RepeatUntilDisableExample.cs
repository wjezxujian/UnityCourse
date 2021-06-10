using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class RepeatUntilDisableExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(1f))
            .Do(_ => Debug.Log("timer 1s"))
            .RepeatUntilDisable(this)
            .Subscribe(_ => Debug.Log("Reapeat 1s"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
