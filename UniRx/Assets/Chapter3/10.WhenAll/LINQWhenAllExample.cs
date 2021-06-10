using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQWhenAllExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ages = new int[] {18, 19, 20, 10, 50, 100};

        Debug.Log(ages.All(age => age > 9));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
