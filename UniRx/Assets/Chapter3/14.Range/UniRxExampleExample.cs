using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxExampleExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(5, 10).Select(x => x * x).Subscribe(number => Debug.Log(number));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
