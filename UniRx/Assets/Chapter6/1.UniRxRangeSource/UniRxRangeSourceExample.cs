using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Operators;

namespace UniRxSource
{
    public class UniRxRangeSourceExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Range(0, 1).Subscribe(number => Debug.Log(number));
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}