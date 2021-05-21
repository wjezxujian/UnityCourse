using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ReactivePropertyExample : MonoBehaviour
{
    //public Action<int> OnAgeChanged = null;
    //private int mAge = 0;

    //public int Age
    //{
    //    get { return mAge; }

    //    set
    //    {
    //        if (mAge != value)
    //        {
    //            mAge = value;

    //            if (OnAgeChanged != null)
    //            {
    //                OnAgeChanged(value);
    //            }
    //        }
    //    }
    //}

    //public ReactiveProperty<int> Age = new ReactiveProperty<int>(0);
    public IntReactiveProperty Age = new IntReactiveProperty(0);  //可以序列化

    // Start is called before the first frame update
    void Start()
    {
        //OnAgeChanged += age => { Debug.Log("inner received age changed"); };

        Age.Subscribe(age => { Debug.Log("Inner received age changed: " + age); });

        Age.Value = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//public class PersonView
//{
//    ReactivePropertyExample reactivePropertyExample;

//    void Init()
//    {
//        reactivePropertyExample.Age.Subscribe((age) =>
//        {
//            Debug.Log("Age Changed:" + age);
//        });
//    }
//}
