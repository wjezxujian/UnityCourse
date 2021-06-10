using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//Defer在Subscribe时生成新的Observable
public class DeferExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var random = new System.Random();

        Observable.Defer(() => Observable.Start(() => random.Next()))
            .Delay(TimeSpan.FromMilliseconds(1000))
            .Repeat()
            .Subscribe(randomNumber => Debug.Log(randomNumber));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
