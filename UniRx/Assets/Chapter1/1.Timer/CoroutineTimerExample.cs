using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UniRxLesson
{
    public class CoroutineTimerExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Timer(5f, () =>
            {
                Debug.Log("CoroutineTimerExample: Do Something.");
            }));
        }

        IEnumerator Timer(float seconds, Action callback)
        {
            yield return new WaitForSeconds(seconds);
            callback();
        }
    }
}