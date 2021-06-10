using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxTakeWhileExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButton(0))
            .TakeWhile((_, number) => !Input.GetMouseButtonUp(0) && number < 100).Subscribe(_ => {
                Debug.Log("Mouse button Clicking.");
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
