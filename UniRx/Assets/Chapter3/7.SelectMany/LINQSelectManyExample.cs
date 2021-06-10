using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQSelectManyExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var urls = new List<string>
        {
            "https://swordxu.com",
            "https://wjezxujian.com"
        };

        urls.SelectMany(url => "[" + url + "]")  // new[] { 1, 2 , 3})
            .ToList()
            .ForEach(singChar =>
            {
                Debug.Log(singChar);
            });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
