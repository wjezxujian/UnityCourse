using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class PanelEventLockExample : MonoBehaviour
{
    public Button buttonA, buttonB, buttonC;

    // Start is called before the first frame update
    void Start()
    {
        var aEvents = buttonA.OnClickAsObservable().Select(_ => "A");
        var bEvents = buttonB.OnClickAsObservable().Select(_ => "B");
        var cEvents = buttonC.OnClickAsObservable().Select(_ => "C");

        Observable.Merge(aEvents, bEvents, cEvents)
                    .First()
                    .Subscribe(btnId => {
                        Debug.LogFormat("Button{0} Clicked", btnId);

                        buttonA.interactable = false;
                        buttonB.interactable = false;
                        buttonC.interactable = false;
                        Observable.Timer(TimeSpan.FromSeconds(1.0f)).Subscribe(_ => {
                            gameObject.SetActive(false);
                        });
                    });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
