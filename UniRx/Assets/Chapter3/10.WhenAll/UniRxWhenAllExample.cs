using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UniRxWhenAllExample : MonoBehaviour
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

        

        var leftClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Take(3).Select(_ => {
            Debug.Log("Left Mouse Clicked.");
            return Unit.Default; 
        });
        var rightClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1)).Take(3).Select(_ =>
        {
            Debug.Log("Right Mouse Clicked.");
            return Unit.Default;
        });

        Observable.WhenAll(aStream, bStream, cStream, leftClickStream, rightClickStream).Subscribe(_ =>
        {
            Debug.Log("All Coroutine Completed.");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
