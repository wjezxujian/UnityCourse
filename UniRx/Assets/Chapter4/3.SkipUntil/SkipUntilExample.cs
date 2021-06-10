using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class SkipUntilExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var leftMouseClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));


        this.UpdateAsObservable().SkipUntil(leftMouseClickStream).Take(100).Repeat().Subscribe(_ =>
        {
            Debug.Log("Mouse clicked.");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
