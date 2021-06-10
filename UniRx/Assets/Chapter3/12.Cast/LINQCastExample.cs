using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;




public class LINQCastExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var infos = new List<object> { "lemon", "apple", "melon" };
        infos.Cast<string>().ToList().ForEach(fruit => Debug.Log(fruit));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
