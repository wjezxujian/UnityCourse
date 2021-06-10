using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TakeUntilDestroyExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0))
            .TakeUntilDestroy(this)
            .Subscribe(_ => Debug.Log("Mouse clicked."));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
