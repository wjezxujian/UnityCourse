using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactiveCommandExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var reactiveCommand = new ReactiveCommand();

        reactiveCommand.Subscribe(_ =>
        {
            Debug.Log("Execute");
        });

        reactiveCommand.Execute();
        reactiveCommand.Execute();
        reactiveCommand.Execute();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
