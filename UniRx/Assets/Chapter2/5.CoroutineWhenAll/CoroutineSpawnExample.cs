using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CoroutineSpawnExample : MonoBehaviour
{
    IEnumerator A()
    {
        yield return new WaitForSeconds(1.0f);

        Debug.Log("A");
    }

    IEnumerator B()
    {
        yield return new WaitForSeconds(2.0f);

        Debug.Log("B");
    }    

    // Start is called before the first frame update
    void Start()
    {
        var aStream = Observable.FromCoroutine(A);
        var bStream = Observable.FromCoroutine(B);

        Observable.WhenAll(aStream, bStream).Subscribe(_ =>
        {
            Debug.Log("When All ¥¶¿Ì¡À°£");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
