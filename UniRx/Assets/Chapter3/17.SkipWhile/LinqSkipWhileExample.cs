using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqSkipWhileExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var grades = new[] { 80, 81, 98, 99, 79, 70, 71, 86, 100 };

        grades.OrderByDescending(grade => grade).SkipWhile(grade => grade >= 80).ToList().ForEach(grade =>
        {
            Debug.Log(grade);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
