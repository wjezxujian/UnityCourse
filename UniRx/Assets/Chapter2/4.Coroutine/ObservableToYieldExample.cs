using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ObservableToYieldExample : MonoBehaviour
{
    IEnumerator Delay1Sceond()
    {
        yield return Observable.Timer(TimeSpan.FromSeconds(1.0f)).ToYieldInstruction();
        Debug.Log("Delay 1 second");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay1Sceond());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
