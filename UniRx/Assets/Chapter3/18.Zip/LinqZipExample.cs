using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqZipExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[] numbers = { 1, 2, 3, 4 };
        string[] words = { "one", "two", "three" };

        var numbersAndWords = numbers.Zip(words, (first, second) => first + ":" + second);

        numbersAndWords.ToList().ForEach(item => Debug.Log(item));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
