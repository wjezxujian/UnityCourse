using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxDistinctExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var leftMouseClickStrem = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => "LeftMouseClicked");
        var rightMouseClickSteam = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Select(_ => "RightMouseClicked");

        Observable.Merge(leftMouseClickStrem, rightMouseClickSteam)
                  .Distinct()
                  .Subscribe(mouseEvent =>
                  {
                      Debug.Log(mouseEvent);
                  });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
