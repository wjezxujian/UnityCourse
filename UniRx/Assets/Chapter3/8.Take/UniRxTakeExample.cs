using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxTakeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
                  .Where(_ => Input.GetMouseButtonDown(0))
                  .Take(5)
                  .Subscribe(_ =>
                  {
                        Debug.Log("LeftMouseButton CLicked");
                  });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
