using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQSkipExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var grades = new[] { 99, 100, 99, 50, 100, 10, 60, 70 };

        grades.OrderByDescending(x => x).Skip(2).ToList().ForEach(grade =>
        {
            Debug.Log(grade);
        });

    }

}
