using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TakeUntilDisableExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .Do(_ => Debug.Log("do mouse button downed."))
            .TakeUntilDisable(this)
            .Subscribe(_ => Debug.Log("Mouse clicked."));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void Awake()
    {
        Debug.Log("Awake");
    }
}
