using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TakeUntilExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var observabel = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        observabel.Subscribe(_ => Debug.Log("Mouse clicked"));
        Observable.EveryUpdate().TakeUntil(observabel).Subscribe(_ => Debug.Log("Out put until mouse click"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
