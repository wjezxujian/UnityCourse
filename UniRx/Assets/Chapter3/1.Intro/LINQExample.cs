using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class LINQExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var urls = new List<string>() { "http://www.baidu.com", "https://www.google.com", "baidu.com" };

        //urls.ForEach(url => Debug.Log(url));

        //Debug.Log("Urls.First: "+ urls.First());

        urls.Where(url => url != "baidu.com")
            .ToList()
            .ForEach(url => Debug.Log(url));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
