using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQTakeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var names = new string[]
        {
            "xujian",
            "leon",
            "wjezxujian",
            "swordxu"
        };

        names.Take(3).ToList().ForEach(name =>
        {
            Debug.Log(name);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
