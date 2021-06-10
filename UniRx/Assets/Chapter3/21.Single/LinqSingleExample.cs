using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqSingleExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ages = new[] { 1, 2, 3, 4, 5 };
        Debug.Log(ages.Single(age => age == 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
