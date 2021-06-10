using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StartWithExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Return("swordxu.com")
            .StartWith("https:", "//").Aggregate((current, next) => current + next).Subscribe(name => Debug.Log(name));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
