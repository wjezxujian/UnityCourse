using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ForEachAsyncExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(0, 10).ForEachAsync(number => Debug.LogFormat("ForEachAsync: {0}", number))
            .Subscribe(number => Debug.LogFormat("Subscribe: {0}", number));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
