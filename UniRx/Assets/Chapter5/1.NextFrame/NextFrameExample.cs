using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class NextFrameExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.frameCount);

        StartCoroutine(NextFrame(() => Debug.Log("Coroutine:" + Time.frameCount)));

        Observable.NextFrame().Subscribe(_ => Debug.Log("UniRx: " + Time.frameCount));
    }

    IEnumerator NextFrame(Action callbalc)
    {
        //yield return null;
        yield return new WaitForEndOfFrame();

        callbalc();
    }
}
