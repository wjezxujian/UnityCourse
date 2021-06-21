using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldTestExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var enumratorTest = new IEnumeratorTest();

        foreach(var item in enumratorTest)
        {
            Debug.Log(item);
        }
    }


    class IEnumeratorTest
    {
        public IEnumerator GetEnumerator()
        {
            //yield return 1;
            //yield return 2;
            //yield return "Ã¶¾ÙÆ÷";

            return new Enumerator(0);
        }

        public class Enumerator : IEnumerator
        {
            private int state;
            private object current;

            public Enumerator(int state)
            {
                this.state = state;
            }

            public object Current {
                get { return current; }
            }

            public bool MoveNext()
            {
                switch (state) {
                    case 0:
                        state++;
                        current = 1;
                        return true;
                    case 1:
                        state++;
                        current = 2;
                        return true;
                    case 2:
                        state++;
                        current = "Ã¶¾ÙÆ÷";
                        return true;
                    default:
                        return false;
                };
            }

            public void Reset()
            {
                state = 0;
            }
        }
    }

}
