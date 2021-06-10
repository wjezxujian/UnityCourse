using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQRangeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enumerable.Range(5, 10).Select(x => x * x)
            .ToList()
            .ForEach(number =>
            {
                Debug.Log(number);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
