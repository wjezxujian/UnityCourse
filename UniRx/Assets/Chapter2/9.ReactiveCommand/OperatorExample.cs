using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OperatorExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var reactiveCommand = new ReactiveCommand<int>();

        reactiveCommand.Where(x => x % 2 == 0).Subscribe(x => Debug.LogFormat("{0} 是 偶数", x));
        reactiveCommand.Where(x => x % 2 != 0).Timestamp().Subscribe(x => Debug.LogFormat("{0} 是基数数 {1}", x.Value, x.Timestamp));

        reactiveCommand.Execute(10);
        reactiveCommand.Execute(11);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
