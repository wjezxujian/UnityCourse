using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LinqTakeWhileExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var fruits = new string[] { "apple", "mango", "orange", "banana", "melong" };

        fruits.TakeWhile(fruit => fruit != "orange").ToList().ForEach(fruit =>
        {
            Debug.Log(fruit);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
