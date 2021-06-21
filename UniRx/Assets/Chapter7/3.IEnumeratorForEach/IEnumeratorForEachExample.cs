using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeratorForEachExample : MonoBehaviour
{
    class ForEachable : IEnumerable
    {
        object[] mObjArray = new object[4] { 1, 2, 3, 4 };

        public IEnumerator GetEnumerator()
        {
            return mObjArray.GetEnumerator();
        }

        


    }

    // Start is called before the first frame update
    void Start()
    {
        var ienumerator = new ForEachable().GetEnumerator();

        while (ienumerator.MoveNext())
        {
            Debug.Log(ienumerator.Current);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
