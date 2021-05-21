using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactiveDictionary : MonoBehaviour
{
    private ReactiveDictionary<string, string> languageCode = new ReactiveDictionary<string, string>()
    {
        {"cn", "����"},
        {"en", "Ӣ��"}
    };

    // Start is called before the first frame update
    void Start()
    {
        languageCode.ObserveAdd().Subscribe(code => Debug.LogFormat("Add: {0}", code));
        languageCode.ObserveRemove().Subscribe(code => Debug.LogFormat("Removed: {0}", code));
        languageCode.ObserveCountChanged().Subscribe(count => Debug.LogFormat("Count: {0}", count));

        languageCode.Add("jp", "����");
        languageCode.Remove("en");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
