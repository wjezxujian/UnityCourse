using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxFirstExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().First(_ => Input.GetMouseButtonDown(0)).Subscribe(_ =>
        {
            Debug.Log("Mouse Down");
        }).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
