using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineImplementationExample : MonoBehaviour
{
    private Update2CoroutineTest update2CoroutineTest = new Update2CoroutineTest();
    IEnumerator mE;

    private void Awake()
    {
        mE = update2CoroutineTest.GetEnumerator();

        StartCoroutine(update2CoroutineTest.GetEnumerator());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(mE.MoveNext())
        //{

        //}
    }

    class Update2CoroutineTest
    {
        public IEnumerator GetEnumerator()
        {
            Debug.Log("Э�̣�" + 1);
            yield return 0;
            Debug.Log("Э�̣�" + 2);
            yield return 0;
            Debug.Log("Э�̣�" + "ö����");
            yield return 0;
        }
    }
}
