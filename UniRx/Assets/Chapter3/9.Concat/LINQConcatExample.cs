using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQConcatExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var aClassAges = new[] { 3, 4, 5, 6 };
        var bClassAges = new[] { 1, 3, 5, 7 };

        aClassAges.Concat(bClassAges)
                  .ToList()
                  .ForEach(age =>
                  {
                      Debug.Log(age);
                  });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
