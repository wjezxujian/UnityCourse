using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(var _ in FiveTimes())
        {
            Debug.Log("Êä³ö");
        }

        StartCoroutine(FourTimes());
    }

    IEnumerable FiveTimes()
    {
        for (var i = 0; i < 5; ++i)
        {
            yield return string.Empty;
        }
    }

    IEnumerator FourTimes()
    {
        for(int i = 0;  i < 4; ++i)
        {
            yield return string.Empty;
            Debug.Log("IEnumerator");
        }
    }
}
