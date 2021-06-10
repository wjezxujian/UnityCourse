using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxLastExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var observable = Observable.Create<int>(observable =>
        {
            observable.OnNext(1);
            observable.OnNext(2);
            observable.OnNext(3);
            observable.OnCompleted();
            return Disposable.Create(() => { Debug.Log("dispose"); });
        });

        observable.Last(x => x < 3).Subscribe(value => {
            Debug.Log(value);
        }, () => { });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
