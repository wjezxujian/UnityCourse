using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxLesson
{
    public class IntroExample : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            Observable.EveryUpdate()            //开启Update的事件监听
                        .Where(_ => Input.GetMouseButtonDown(0))    //进行一个事件筛选
                        .First()
                        .Subscribe(_ => { Debug.Log("mouse clicked"); });  //订阅处理事件
        }

    }
}


