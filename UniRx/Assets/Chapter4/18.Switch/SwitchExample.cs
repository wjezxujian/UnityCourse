using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SwitchExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var buttonDownStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        //var buttonUpStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0));

        //buttonDownStream.Select(_ =>
        //{
        //    Debug.Log("Mouse Button Down");
        //    return buttonUpStream;
        //}).Switch().Subscribe(_ => Debug.Log("Mouse Button Up"));


        var stateJump = Observable.Return("Jump State");

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Select(_ => stateJump)
            .Switch()
            .Subscribe(stateName => Debug.Log(stateName));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
