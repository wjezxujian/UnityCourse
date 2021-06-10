using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqRepeatExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enumerable.Repeat("sowrdxu.com", 10)
            .ToList()
            .ForEach(name => Debug.Log(name));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
