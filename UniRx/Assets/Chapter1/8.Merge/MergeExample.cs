using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MergeExample : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var leftClickEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        var rightClickEvents = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));

        Observable.Merge(leftClickEvents, rightClickEvents)
                    .Subscribe(_ =>
                    {
                        Debug.Log("Mouse Clicked");
                    });


    }
}
