using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class LinqEmptyExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var emptyList = Enumerable.Empty<string>().ToList();
        Debug.Log(emptyList.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
