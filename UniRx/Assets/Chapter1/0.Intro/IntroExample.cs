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
            Observable.EveryUpdate()            //����Update���¼�����
                        .Where(_ => Input.GetMouseButtonDown(0))    //����һ���¼�ɸѡ
                        .First()
                        .Subscribe(_ => { Debug.Log("mouse clicked"); });  //���Ĵ����¼�
        }

    }
}


