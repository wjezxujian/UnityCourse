using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

//���ÿ����ڴ�ռ���Subject
public class NeverExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var never = Observable.Never<string>();

        never.Subscribe(_ => Debug.Log(_), () => { Debug.Log("On Completed."); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
