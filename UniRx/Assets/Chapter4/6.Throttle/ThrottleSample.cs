using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//�¼������೤ʱ����ٴδ���
public class ThrottleSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0)).
            Throttle(TimeSpan.FromSeconds(5f))
            .Subscribe(_ => Debug.Log("�������ʱ5��֮�����"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
