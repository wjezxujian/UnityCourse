using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniTakeLastExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(5, 5).TakeLast(3).Subscribe(number => Debug.Log(number));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
