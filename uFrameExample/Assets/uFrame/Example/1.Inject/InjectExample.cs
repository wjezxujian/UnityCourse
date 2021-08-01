using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uFrame.IOC;

public class InjectExample : MonoBehaviour
{
    [Inject] public A AObj { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        var container = new UFrameContainer();

        container.RegisterInstance(new A());

        container.Inject(this);

        AObj.LogSelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class A
    {
        public void LogSelf()
        {
            Debug.Log("A");
        }
    }
}
