using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class AllButtonClickedOnceExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var leftMouseCLickedEvent = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).First();
        var rightMouseCLickedEvent = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).First();

        Observable.WhenAll(leftMouseCLickedEvent, rightMouseCLickedEvent)
            .Subscribe(_ =>
            {
                Debug.Log("mouse clicked");
            });
    }
}
