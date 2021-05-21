using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FirstExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
                    //.Where(_ => Input.GetMouseButtonDown(0))
                    .First(_ => Input.GetMouseButtonDown(0))
                    .Subscribe(_ => { Debug.Log("FirstExample: Mouse Click."); })
                    .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
