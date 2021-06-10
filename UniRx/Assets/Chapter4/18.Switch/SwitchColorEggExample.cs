using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchColorEggExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //W A S D´¥·¢²Êµ°

        var wObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.W));
        var aObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.A));
        var sObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.S));
        var dObservable = Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.D));

        wObservable.
            Select(_ => aObservable).Switch().
            Select(_ => sObservable).Switch().
            Select(_ => dObservable).Repeat().
            Subscribe(_ => Debug.Log("´¥·¢²Êµ°¡£"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
