using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQDistinctExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var urls = new List<string>
        {
            "http://www.swordxu.com",
            "http://www.swordxu.com",
            "https://www.wjezxujian.com",
            "https://ww.wjezxujian.com",
            "https://www.swordxu.com",
            "http://w.wjezxujian.com",
            "https://www.wjezxujian.com"
        };

        urls.Distinct().ToList().ForEach(url =>
        {
            Debug.Log(url);
        });

        var distinctUrls =(from url in urls select url).Distinct();
        distinctUrls.ToList().ForEach(url =>
        {
            Debug.Log(url);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
