using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;


public class CoroutineExample : MonoBehaviour
{
    IEnumerator CoroutineA()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("A");
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(CoroutineA());

        Observable.FromCoroutine(CoroutineA).Subscribe(_ =>{});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
