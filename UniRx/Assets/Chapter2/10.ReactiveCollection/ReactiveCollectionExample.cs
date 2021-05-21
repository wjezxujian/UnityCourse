using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactiveCollectionExample : MonoBehaviour
{
    public ReactiveCollection<string> names = new ReactiveCollection<string> {
            "xu", "jian", "niubility"
        };

    // Start is called before the first frame update
    void Start()
    {
        foreach(var name in names)
        {
            Debug.Log(name);
        }

        names.ObserveAdd().Subscribe(name => Debug.LogFormat("Add: {0}", name));
        names.ObserveRemove().Subscribe(removedName => Debug.LogFormat("Removed: {0}", removedName));
        names.ObserveCountChanged().Subscribe(count => Debug.LogFormat("Count: {0}", count));

        names.Add("xuxu");
        names.Remove("niubility");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
