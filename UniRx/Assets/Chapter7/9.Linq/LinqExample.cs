using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class LinqExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enumerable.Range(1, 10)
            .Where(number => number % 2 == 1)
            .Select(number => number * number)
            .ToList()
            .ForEach(number => Debug.Log(number));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
