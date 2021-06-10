using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class RepeatUntilDestroyExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(1f))
            .RepeatUntilDestroy(this)
            .Subscribe(_ => Debug.Log("ticked"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
