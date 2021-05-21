using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MouseUpDownExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var mouseDownStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_ => true);
        var mouseUpStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)).Select(_ => false);

        var isMouseUp = Observable.Merge(mouseDownStream, mouseUpStream);

        var reactiveCommand = new ReactiveCommand(isMouseUp, false);

        reactiveCommand.Subscribe(_ =>
        {
            Debug.Log("reactiveCommand command executed;");
        });

        Observable.EveryUpdate().Subscribe(_ => { reactiveCommand.Execute(); });
    }
}
