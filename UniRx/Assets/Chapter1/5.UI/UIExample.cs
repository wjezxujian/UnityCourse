using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class UIExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var button = transform.Find("Button").GetComponent<Button>();

        button.OnClickAsObservable()
            .Subscribe(_ => { Debug.Log("UIExample: Button Clicked."); })
            .AddTo(this);

        var toggle = transform.Find("Toggle").GetComponent<Toggle>();

        toggle.OnValueChangedAsObservable()
            .Where(on => on)
            .Subscribe(on => Debug.Log("UIExample Toggle: " + on));

        var image = transform.Find("Image").GetComponent<Graphic>();
        image.OnBeginDragAsObservable().Subscribe(_ => Debug.Log("UIExample Began Drag."));
        image.OnDragAsObservable().Subscribe(_ => Debug.Log("UIExample Dragging."));
        image.OnEndDragAsObservable().Subscribe(_ => Debug.Log("UIExample End Drag."));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
