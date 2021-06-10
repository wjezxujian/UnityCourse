using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LINQOfTypeExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var infos = new ArrayList() { 1, 2, 3, 4, 5, "6", 7.0f, 8.0f};

        infos.OfType<float>().ToList().ForEach(info =>
        {
            Debug.Log(info);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
