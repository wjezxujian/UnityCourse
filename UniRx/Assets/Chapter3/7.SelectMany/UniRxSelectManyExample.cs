using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;

public class UniRxSelectManyExample : MonoBehaviour
{
    IEnumerator A()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("A");
    }

    IEnumerator B()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("B");
    }

    IEnumerator C()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("C");
    }

    // Start is called before the first frame update
    void Start()
    {
        var aStream = Observable.FromCoroutine(A);
        var bStream = Observable.FromCoroutine(B);
        var cStream = Observable.FromCoroutine(C);

        //cStream.SelectMany(bStream).SelectMany(aStream).Subscribe();
        cStream.SelectMany(bStream.SelectMany(aStream)).Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
