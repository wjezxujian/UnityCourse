using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqToListExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var fruits = new[] { "apple", "orange", "banana", "pineapple" };

        fruits.Select(fruit => fruit.Length).ToList().ForEach(length => Debug.Log(length));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
