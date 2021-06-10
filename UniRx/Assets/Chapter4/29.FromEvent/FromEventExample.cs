using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.UI;

public class FromEventExample : MonoBehaviour
{
    event Action onMouseDownEvent;

    event Action OnClickEvent;

    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => onMouseDownEvent.Invoke());

        Observable.FromEvent(mouseDownEvent => onMouseDownEvent += mouseDownEvent, mouseDownEvent => onMouseDownEvent -= mouseDownEvent)
            .Subscribe(_ => Debug.Log("mouse clicked"));


        transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => { OnClickEvent(); });
        Observable.FromEvent(action => OnClickEvent += action, action => OnClickEvent -= action)
        .Subscribe(_ => Debug.Log("button clicked"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
