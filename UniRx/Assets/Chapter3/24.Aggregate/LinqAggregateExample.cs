using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqAggregateExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ages = new[] { 80, 60, 40, 20, 55 };

        var minAge = ages.Aggregate((minAge, nextAge) => minAge > nextAge ? nextAge : minAge);
        Debug.Log(minAge);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
