using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class UITriggerExample : MonoBehaviour
{
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = transform.Find("Image").GetComponent<Image>();

        image.OnBeginDragAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("On Begin drag");
            });

        image.OnPointerClickAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("On pointer click");
            });

        image.OnDragAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("On Drag");
            });

        image.OnEndDragAsObservable()
            .Subscribe(_ =>
            {
                Debug.Log("On End Drag");
            });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
