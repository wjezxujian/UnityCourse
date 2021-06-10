using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxSkipWhileExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().SkipWhile((_, times) => !Input.GetMouseButtonDown(0) && times < 100).Subscribe(_ => Debug.Log("Event log"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
