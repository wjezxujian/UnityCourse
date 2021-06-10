using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class UniRxSelectExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Select(_ => "mouse down")
                  .Subscribe(mouseEventName =>
                  {
                      Debug.Log(mouseEventName);
                  }).AddTo(this);


        var query = from mouseEvent in Observable.EveryUpdate() where Input.GetMouseButtonDown(0) select "mouse down";
        query.Subscribe(mouseEventName =>
        {
            Debug.Log(mouseEventName);
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
