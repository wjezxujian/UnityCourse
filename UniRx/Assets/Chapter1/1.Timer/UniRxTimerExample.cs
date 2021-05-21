using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace UniRxLesson
{
    public class UniRxTimerExample : MonoBehaviour
    {

        // Start is called before the first frame update
        private void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(5.0f))
                         .Subscribe(_ => { Debug.Log("UniRxTimerExample: Do Something."); }).AddTo(this);
        }

    }
}


