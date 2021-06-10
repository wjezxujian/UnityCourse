using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PairWiseExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(0, 10).Pairwise((previous, current) => current + " : " + previous).Subscribe(result => Debug.Log(result));
        //Observable.Range(0, 10).Pairwise().Subscribe(pair => Debug.Log(pair.Current + " : " + pair.Previous));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
