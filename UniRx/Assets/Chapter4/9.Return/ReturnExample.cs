using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReturnExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Return("hello").Subscribe(hello => Debug.Log(hello));
        Debug.Log("hero");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
