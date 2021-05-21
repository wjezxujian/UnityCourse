using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class OnCompletedExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Observable.Timer(TimeSpan.FromSeconds(1.0f)).Subscribe(_ =>
        //{
        //    Debug.Log("OnNext: after 1 second");
        //}, () => { Debug.Log("OnCompleted."); });

        //Observable.EveryUpdate().First().Subscribe(_ => {
        //    Debug.Log("OnNext: First");
        //}, () => { Debug.Log("OnCompleted."); });

        Observable.FromCoroutine(A).Subscribe(_ =>
        {
            Debug.Log("OnNext:");
        }, () => Debug.Log("On Completed."));
    }

    // Update is called once per frame
    IEnumerator A()
    {
        yield return new WaitForSeconds(2.0f);
    }
}
