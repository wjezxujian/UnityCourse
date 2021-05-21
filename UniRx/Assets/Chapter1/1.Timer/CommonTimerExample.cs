using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace UniRxLesson
{
    public class CommonTimerExample : MonoBehaviour
    {
        private float mStartTime;

        // Start is called before the first frame update
        private void Start()
        {
            mStartTime = Time.time;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Time.time - mStartTime > 5f)
            {
                Debug.Log("CommonTimerExample: Do something.");

                mStartTime = float.MaxValue;
            }
        }
    }

}


