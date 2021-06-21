using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeratorExample : MonoBehaviour
{
    class ForEachable : IEnumerable
    {
        int mCount;

        public ForEachable(int count)
        {
            mCount = count;
        }

        public IEnumerator GetEnumerator()
        {
            return new FiveTimes(mCount);
        }
    }

    class FiveTimes : IEnumerator
    {
        int mInitialCount = 0;

        public FiveTimes(int count)
        {
            mCount = mInitialCount = count;
        }

        public object Current { get { return string.Empty; } }

        int mCount = 5;

        public bool MoveNext()
        {
            mCount--;
            return mCount >= 0;
        }

        public void Reset()
        {
            mCount = mInitialCount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var forEachable = new ForEachable(10);

        foreach(var item in forEachable)
        {
            Debug.Log("Êä³ö");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
