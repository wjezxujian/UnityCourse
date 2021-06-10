using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ThrowExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Throw<string>(new System.Exception("error"))
            .Subscribe(_ => Debug.Log("²»»áÊä³ö"), ex => Debug.LogException(ex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
