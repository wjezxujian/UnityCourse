using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class UpdateAPIExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.UpdateAsObservable().Subscribe(_ =>
        //{
        //    Debug.LogFormat("EveryUpdate {0}", this.gameObject.name);
        //    Update();
        //});

        this.OnDestroyAsObservable().Subscribe(_ =>
        {
            Debug.LogFormat("On Destroy AsObservable {0}", this.gameObject.name);
        });

        //MainThreadDispatcher
        //Observable.EveryUpdate().Subscribe(_ =>
        //{
        //    Debug.LogFormat("EveryUpdate {0}", this.gameObject.name);
        //    Update();
        //}).AddTo(this);
        //Observable.EveryFixedUpdate().Subscribe(_ => { Debug.Log("EveryFixedUpdate"); });
        //Observable.EveryEndOfFrame().Subscribe(_ => { Debug.Log("EveryEndOfFrame"); });
        //Observable.EveryLateUpdate().Subscribe(_ => { Debug.Log("EveryLateUpdate"); });
        //Observable.EveryAfterUpdate().Subscribe(_ => { Debug.Log("EveryAfterUpdate"); });

        Observable.OnceApplicationQuit().Subscribe(_ =>
        {
            Debug.Log("OnceApplicationQuit");
        });

        Observable.EveryApplicationFocus().Subscribe(_ =>
        {
            Debug.Log("EveryApplicationFocus");
        });
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
}
