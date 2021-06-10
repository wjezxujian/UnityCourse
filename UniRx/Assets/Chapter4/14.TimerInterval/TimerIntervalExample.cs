using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

//�¼�ʱ����ת��ΪTimeInterval��ʽ��ʱ���
public class TimerIntervalExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Interval(TimeSpan.FromMilliseconds(750f)).TimeInterval().Subscribe(timerInterval => Debug.LogFormat("{0}, {1}", timerInterval.Interval, timerInterval.Value));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
