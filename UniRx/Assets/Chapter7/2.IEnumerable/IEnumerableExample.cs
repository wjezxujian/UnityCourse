using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumerableExample : MonoBehaviour
{
    class ForEachable : IEnumerable
    {
        object[] mObjectArray = new object[4] {"1", "2", "3", "4" };

        public IEnumerator GetEnumerator()
        {
            return mObjectArray.GetEnumerator();
        }
    }

    private void Start()
    {
        var foreachable = new ForEachable();

        foreach(var number in foreachable)
        {
            Debug.Log(number);
        }
    }
}
